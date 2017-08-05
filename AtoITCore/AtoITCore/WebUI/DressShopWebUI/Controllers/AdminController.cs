using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using static System.DateTime;



namespace DressShopWebUI.Controllers
{
    /// <summary>
    /// Контроллер для админ - панели
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        private static readonly ShopContext Db = new ShopContext();

        #region Работа с товарами

        //------------------------------------------------Стартовая страница------------------------------------------------------------------
        [HttpGet]
        public ActionResult MyPanel()
        {    // Костылииииииии!!!! :)))
            List<Product> product = new List<Product>();

            var selectProduct = from s in Db.Product
                                select s;
            var selectPhoto = from s in Db.Photo
                              select s;

            foreach (var p in selectProduct)
            {
                product.Add(p);
            }
            foreach (var p in product)
            {
                foreach (var s in selectPhoto)
                {
                    if (p.ProductId == s.Product.ProductId)
                    {
                        p.Photo.Add(s);
                    }
                }
            }

            return View(product);
        }

        [HttpPost]
        //Сортировка и поиск по имени продукта
        public ActionResult MyPanel(string searchName, CategoryProduct category)
        {
            var product = from s in Db.Product
                          select s;
            if (!string.IsNullOrEmpty(searchName))
            {
                product = product.Where(s => s.Name.Equals(searchName));


                if (product.Count() != 0)
                {
                    TempData["message"] = $"Выбран товар по имени - \"{searchName}\"";
                    return PartialView("PartialMyPanel", product.ToList());
                }

                product = from s in Db.Product
                          select s;
                TempData["message"] = $"Товара с именем - \"{searchName}\" не существует!";
                return PartialView("PartialMyPanel", product.ToList());
            }
            switch (category)
            {

                case CategoryProduct.Selling:
                    product = product.Where(x => x.Category == "Selling");
                    break;
                case CategoryProduct.Gallery:
                    product = product.Where(x => x.Category == "Gallery");
                    break;
                case CategoryProduct.Partners:
                    product = product.Where(x => x.Category == "Partners");
                    break;
            }
            return PartialView("PartialMyPanel", product.ToList());
        }

        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------Добавление товара-------------------------------------------------------------------
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase upload, IEnumerable<HttpPostedFileBase> uploads)
        {
            if (ModelState.IsValid && upload != null)
            {
                List<Photo> list = new List<Photo>();
                var photoName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(upload.FileName);
                photoName += extension;
                List<string> extensions = new List<string> { ".jpg", ".png", ".gif" };
                // сохраняем файл
                if (extensions.Contains(extension))
                {
                    upload.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
                    list.Add(new Photo { PhotoUrl = photoName, Priority = true });
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка! Не верное расширение фотографии!");
                    return View();
                }
                foreach (var file in uploads)
                {

                    if (file != null)
                    {
                        photoName = Guid.NewGuid().ToString();
                        extension = Path.GetExtension(file.FileName);
                        photoName += extension;
                        // сохраняем файл в папку Files в проекте
                        if (extensions.Contains(extension))
                        {
                            file.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
                            list.Add(new Photo { PhotoUrl = photoName, Priority = false });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Ошибка! Не верное расширение фотографии!");
                            return View();
                        }
                    }
                }

                Db.Product.Add(new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Discount = product.Discount,
                    Category = product.Category,
                    Price = product.Price,
                    SpecOffer = product.SpecOffer,
                    DateCreate = Now,
                    Photo = list
                });
                Db.SaveChanges();
                TempData["message"] = "Товар успешно добавлен!";
                return RedirectToAction("MyPanel");
            }
            ModelState.AddModelError("", "Ошибка! Товар не был добавлен! проверьте пожалуйста правильность заполнения формы!");
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------Редактировние товара----------------------------------------------------------------
        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            var product = Db.Product.FirstOrDefault(x => x.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var pro = Db.Product.Find(product.ProductId);
                if (pro != null)
                {
                    pro.Discount = product.Discount;
                    pro.Category = product.Category;
                    pro.Description = product.Description;
                    pro.Name = product.Name;
                    pro.Price = product.Price;
                    pro.SpecOffer = product.SpecOffer;
                    Db.SaveChanges();

                }
                TempData["message"] = "Изменения в товаре были сохранены";
            }
            var productSelect = Db.Product.FirstOrDefault(x => x.ProductId == product.ProductId);
            return View("EditProduct", productSelect);

        }

        //------------------------------------------------Удаление товара---------------------------------------------------------------------
        [HttpPost]
        public ActionResult DeleteProduct(int productId, string category)
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
            var product = Db.Product.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                var removePhotos = from i in Db.Photo
                    where i.Product.ProductId == productId
                    select i;
                foreach (var i in removePhotos)
                {
                //    foreach (FileInfo file in directory.GetFiles())  //Удаление фото из директории пока закоментирую
                //    {
                //        if (file.ToString() == i.PhotoUrl)
                //        file.Delete();
                //    }
                    Db.Photo.Remove(i);
                }
               
                Db.Product.Remove(product);
                Db.SaveChanges();
            }
            List<Product> model = new List<Product>();
         
            var selectProduct = from s in Db.Product
                                where s.Category == category
                                select s;
            var selectPhoto = from s in Db.Photo
                              select s;

            foreach (var p in selectProduct)
            {
                model.Add(p);
            }
            foreach (var p in model)
            {
                foreach (var s in selectPhoto)
                {
                    if (p.ProductId == s.Product.ProductId)
                    {
                        p.Photo.Add(s);
                    }
                }
            }

            return PartialView("PartialMyPanel", model);
        }

        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------Редактот фото товара----------------------------------------------------------------
        [HttpPost]
        public ActionResult PriorityСhangesPhoto(int idProduct, int id) // Изменение приоритета фото
        {
            var photoFromSelect = Db.Photo.FirstOrDefault(x => x.PhotoId == id);
            var response = from i in Db.Photo
                           where i.Product.ProductId == idProduct
                           select i;
            foreach (var i in response)
            {
                if (i != null)
                    i.Priority = false;
            }
            if (photoFromSelect != null)
            {
                photoFromSelect.Priority = true;
                Db.SaveChanges();
            }

            return PartialView("EditPhoto", response.ToList());

        }

        [HttpPost]
        public ActionResult DeletePhoto(int idProduct, int id = 0) // Удаление фото
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
            List<Photo> response = new List<Photo>();
            var photoFromSelect = Db.Photo.FirstOrDefault(x => x.PhotoId == id); //выбираем фото по id
            if (photoFromSelect != null) //если оно есь - удаляем из базы и из дериктории
            {
                //foreach (FileInfo file in directory.GetFiles())      //Пока закоментирую, для удобства
                //{
                //    if (file.ToString() == photoFromSelect.PhotoUrl)
                //        file.Delete();
                //}
                Db.Photo.Remove(photoFromSelect);
                Db.SaveChanges();

            }
            var qvery = from i in Db.Photo
                        where i.Product.ProductId == idProduct
                        select i;

            if (qvery.Any()) //Проверяем, остались ли фото в базе по ID продукта
            {
                if (qvery.FirstOrDefault(x => x.Priority) != null) //Если есть фото с высоким приоритетом - отправляем ответ
                {
                    response = qvery.ToList();
                }
                else
                {
                    var priorityСhangesPhoto = qvery.FirstOrDefault();//Если нет фото с высоким приоритетом - задаем
                    if (priorityСhangesPhoto != null)
                    {
                        priorityСhangesPhoto.Priority = true;
                        Db.SaveChanges();
                        response = qvery.ToList();
                    }
                }

            }
            return PartialView("EditPhoto", response);

        }
        //------------------------------------------------------------------------------------------------------------------------------------





        #endregion

        #region Работа с отзывами
        //------------------------------------------------Стартовая страница------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditingReviews()
        {
            var reviews = from s in Db.Reviews
                          orderby s.DateFeedback descending
                          select s;
            return View(reviews.ToList());
        }

        [HttpPost]
        public ActionResult EditingReviews(SortType sortType)
        {
            var reviews = from a in Db.Reviews select a;
            switch (sortType)
            {

                case SortType.Before:
                    reviews = reviews.OrderByDescending(x => x.DateFeedback);
                    break;
                case SortType.Later:
                    reviews = reviews.OrderBy(x => x.DateFeedback);
                    break;
            }

            return PartialView("PartialEditingReviews", reviews.ToList());
        }


        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------Редактировние отзыва----------------------------------------------------------------
        [HttpGet]
        public ActionResult EditReview(int reviewId)
        {
            var review = Db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(review);
        }

        [HttpPost]
        public ActionResult EditReview(Reviews review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rev = Db.Reviews.Find(review.ReviewId);
                    if (rev != null)
                    {
                        rev.ClientName = review.ClientName;
                        rev.Rating = review.Rating;
                        rev.ClientFeedback = review.ClientFeedback;
                        rev.Advantages = review.Advantages;
                        rev.LackOf = review.LackOf;
                        rev.Email = review.Email;
                        Db.SaveChanges();
                    }

                    TempData["message"] = "Изменения в отзыве были сохранены";
                    return RedirectToAction("EditingReviews");
                }
                TempData["message"] = "Ошибка! Изменения не были сохранены, проверьте данные!";
                return RedirectToAction("EditReview", review.ReviewId);
            }
            catch (Exception)
            {
                TempData["message"] = "Ошибка! мы не смогли сохранить изменения в отзыве :(";
                return RedirectToAction("EditReview", review.ReviewId);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------Удаление отзыва---------------------------------------------------------------------
        [HttpGet]
        public ActionResult DeleteReviews(int reviewId)
        {
            var review = Db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(review);
        }

        [HttpPost]
        public ActionResult DeleteReviews(Reviews review)
        {
            try
            {
                var rev = Db.Reviews.Find(review.ReviewId);
                if (rev != null)
                {
                    Db.Reviews.Remove(rev);
                    Db.SaveChanges();
                }

                TempData["message"] = "Отзыв был успешно удален!";
                return RedirectToAction("EditingReviews");
            }
            catch (Exception)
            {
                //ошибка в базе и т.д.
                TempData["message"] = "Ошибка! Мы не смогли удалить отзыв :( ";
                return RedirectToAction("DeleteReviews", review.ReviewId);
            }

        }
        //------------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
    //emum для сортировки по дате
    public enum SortType
    {
        None = 0,
        Before = 1,
        Later = 2
    }
    //emum для сортировки по категории
    public enum CategoryProduct
    {
        None = 0,
        Selling = 1,
        Gallery = 2,
        Partners = 3
    }

}
