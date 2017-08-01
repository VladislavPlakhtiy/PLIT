using System;
using System.Linq;
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

        // Стартовая страница Админ-панели
        public ActionResult MyPanel()
        {
            var product = from s in Db.Photo
                where s.Priority == true
                orderby s.Product.DateCreate descending
                select s;
            return View(product.ToList());
        }


        // Редактирование товара
        public ViewResult EditProduct(int productId)
        {
            var product = Db.Product.FirstOrDefault(x => x.ProductId == productId);
            return View(product);
        }


        //удаление товара
        public ViewResult DeleteProduct(int productId)
        {
            var product = Db.Product.FirstOrDefault(x => x.ProductId == productId);
            return View(product);
        }


        // добавления товара
        [HttpPost]
        public ActionResult AddProduct()
        {
            return View();
        }




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
            var reviews =from a in Db.Reviews select a;
            switch (sortType)
            {

                case SortType.Before:
                    reviews= reviews.OrderByDescending(x => x.DateFeedback);
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
    public enum SortType
    {
        None = 0,
        Before = 1,
        Later = 2
    }

}
