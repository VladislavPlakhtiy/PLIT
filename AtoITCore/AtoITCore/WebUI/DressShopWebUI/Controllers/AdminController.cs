using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;

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
        public ActionResult AddProduct()
        {
            return View();
        }

      
        // Список отзывов
        public ActionResult EditingReviews()
        {
            var reviews = from s in Db.Reviews
                          orderby s.DateFeedback descending
                          select s;
            return View(reviews.ToList());
        }


        // редактирование отзыва
        public ViewResult EditReview(int reviewId)
        {
            var review = Db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(review);
        }


        //удаление отзыва
        public ViewResult DeleteReviews(int reviewId)
        {
            var review = Db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            return View(review);
        }
        

    }
}