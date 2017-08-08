using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;
using static System.DateTime;



namespace DressShopWebUI.Controllers
{
    /// <summary>
    /// Контроллер для админ - панели
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ShopContext _db = ContextForOllControllers.Db;

        #region Работа с товарами

        //------------------------------------------------Стартовая страница------------------------------------------------------------------
        public ActionResult MyPanel()
        {
            var product = from i in _db.Product.Include("Photo")
                orderby i.DateCreate descending
                select i;
            return View(product.ToList());
        }

        [HttpPost]
        //Сортировка и поиск по имени продукта
        public ActionResult MyPanel(string searchName, CategoryProduct category)
        {
            var product = from s in _db.Product
                          select s;
            if (!string.IsNullOrEmpty(searchName))
            {
                product = product.Where(s => s.Name.Equals(searchName));


                if (product.Count() != 0)
                {
                    TempData["message"] = $"Выбран товар по имени - \"{searchName}\"";
                    return PartialView("PartialMyPanel", product.ToList());
                }

                product = from s in _db.Product
                          select s;
                TempData["message"] = $"Товара с именем - \"{searchName}\" не существует!";
                return PartialView("PartialMyPanel", product.ToList());
            }
            switch (category)
            {

                case CategoryProduct.Selling:
                    product = product.Where(x => x.Category == "Selling");
                    product = product.OrderByDescending(x => x.DateCreate);
                    break;
                case CategoryProduct.Gallery:
                    product = product.Where(x => x.Category == "Gallery");
                    product = product.OrderByDescending(x => x.DateCreate);
                    break;
                case CategoryProduct.Partners:
                    product = product.Where(x => x.Category == "Partners");
                    product = product.OrderByDescending(x => x.DateCreate);
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

                _db.Product.Add(new Product
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
                _db.SaveChanges();
                TempData["message"] = "Товар успешно добавлен!";
                return RedirectToAction("MyPanel");
            }
            ModelState.AddModelError("", "Ошибка! Товар не был добавлен! проверьте пожалуйста правильность заполнения формы и наличие фото!");
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------Редактировние товара----------------------------------------------------------------
        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            var product = _db.Product.FirstOrDefault(x => x.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            var qvery = from i in _db.Photo
                where i.Product.ProductId == product.ProductId
                select i;
            if (ModelState.IsValid && !qvery.Count().Equals(0))
            {
                var pro = _db.Product.Find(product.ProductId);
                if (pro != null)
                {
                    pro.Discount = product.Discount;
                    pro.Category = product.Category;
                    pro.Description = product.Description;
                    pro.Name = product.Name;
                    pro.Price = product.Price;
                    pro.SpecOffer = product.SpecOffer;
                    _db.SaveChanges();
                }
                TempData["message"] = "Изменения в товаре были сохранены";
                return RedirectToAction("MyPanel");
            }
            ModelState.AddModelError("", "Ошибка! Товар не был изменен! проверьте пожалуйста правильность заполнения формы и наличие фото!");
            var productSelect = _db.Product.FirstOrDefault(x => x.ProductId == product.ProductId);
            return View("EditProduct", productSelect);

        }

        //------------------------------------------------Удаление товара---------------------------------------------------------------------
        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            //DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
            var product = _db.Product.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                var removePhotos = from i in _db.Photo
                    where i.Product.ProductId == productId
                    select i;
                foreach (var i in removePhotos)
                {
                //    foreach (FileInfo file in directory.GetFiles())  //Удаление фото из директории пока закоментирую
                //    {
                //        if (file.ToString() == i.PhotoUrl)
                //        file.Delete();
                //    }
                    _db.Photo.Remove(i);
                }
               
                _db.Product.Remove(product);
                _db.SaveChanges();
                TempData["message"] = "Товар был успешно удален!";
            }
            return RedirectToAction("MyPanel");
        }

        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------Редактот фото товара----------------------------------------------------------------
        [HttpPost]
        public ActionResult PriorityСhangesPhoto(int idProduct, int id) // Изменение приоритета фото
        {
            var photoFromSelect = _db.Photo.FirstOrDefault(x => x.PhotoId == id);
            var response = from i in _db.Photo
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
                _db.SaveChanges();
            }

            return PartialView("EditPhoto", response.ToList());

        }

        [HttpPost]
        public ActionResult DeletePhoto(int idProduct, int id = 0) // Удаление фото
        {
            //DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
            List<Photo> response = new List<Photo>();
            var photoFromSelect = _db.Photo.FirstOrDefault(x => x.PhotoId == id); //выбираем фото по id
            if (photoFromSelect != null) //если оно есь - удаляем из базы и из дериктории
            {
                //foreach (FileInfo file in directory.GetFiles())      //Пока закоментирую, для удобства
                //{
                //    if (file.ToString() == photoFromSelect.PhotoUrl)
                //        file.Delete();
                //}
                _db.Photo.Remove(photoFromSelect);
                _db.SaveChanges();

            }
            var qvery = from i in _db.Photo
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
                        _db.SaveChanges();
                        response = qvery.ToList();
                    }
                }

            }
            return PartialView("EditPhoto", response);

        }
        //------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------Добавление фото на сервер-----------------------------------------------------------

        [HttpPost]
        public ActionResult UploadPhoto(int productId, HttpPostedFileBase fileInput)
        {
            var product = _db.Product.FirstOrDefault(x => x.ProductId == productId);
            var photos = from i in _db.Photo
                where i.Product.ProductId == productId
                select i;
            var photoName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(fileInput.FileName);
            photoName += extension;
            List<string> extensions = new List<string> { ".jpg", ".png", ".gif" };
            // сохраняем файл
            if (extensions.Contains(extension))
            {
                fileInput.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
                if (photos.Any())
                {
                    _db.Photo.Add(new Photo
                    {
                        PhotoUrl = photoName,
                        Priority = false,
                        Product = product
                    });
                    _db.SaveChanges();
                }
                else
                {
                    _db.Photo.Add(new Photo
                    {
                        PhotoUrl = photoName,
                        Priority = true,
                        Product = product
                    });
                    _db.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("", "Ошибка! Не верное расширение фотографии!");
                PartialView("EditPhoto", photos.ToList());
            }
            return PartialView("EditPhoto",photos.ToList());
        }
            
        //------------------------------------------------------------------------------------------------------------------------------------


        #endregion

        #region Работа с отзывами
        //------------------------------------------------Стартовая страница------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditingReviews()
        {
            var reviews = from s in _db.Reviews
                          orderby s.DateFeedback descending
                          select s;
            return View(reviews.ToList());
        }

        [HttpPost]
        public ActionResult EditingReviews(SortType sortType)
        {
            var reviews = from a in _db.Reviews select a;
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
            var review = _db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(review);
        }

        [HttpPost]
        public ActionResult EditReview(Reviews review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rev = _db.Reviews.Find(review.ReviewId);
                    if (rev != null)
                    {
                        rev.ClientName = review.ClientName;
                        rev.Rating = review.Rating;
                        rev.ClientFeedback = review.ClientFeedback;
                        rev.Advantages = review.Advantages;
                        rev.LackOf = review.LackOf;
                        rev.Email = review.Email;
                        _db.SaveChanges();
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
            var review = _db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(review);
        }

        [HttpPost]
        public ActionResult DeleteReviews(Reviews review)
        {
            try
            {
                var rev = _db.Reviews.Find(review.ReviewId);
                if (rev != null)
                {
                    _db.Reviews.Remove(rev);
                    _db.SaveChanges();
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
