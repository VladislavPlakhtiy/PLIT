using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;
using MvcPaging;


namespace DressShopWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _db = new ShopContext(); 
        private const int ReviewsPageSize = 5;
        private IList<Reviews> _allReviewses = new List<Reviews>();

        // Стартовая страница
        public ViewResult Index()
        {
            DbSet<Photo> product = _db.Photo;
            if (!product.Any())
                DebugDb.AddToDb();
            IQueryable<Photo> photo = from s in _db.Photo where s.Priority == true select s;
            return View(photo.ToList());
        }
        // страница каталога (ONLINE-гардероб)
        public ViewResult Selling()
        {
            return View();
        }
        // страница Галерея (Паша)
        public ViewResult Gallery()
        {
            return View();
        }
        // страница Партнеры (Паша)
        public ViewResult Partners()
        {
            return View();
        }
        //страница Отзывы(в разработке!!!!)
       
        public ActionResult ClientFeedback(string name, string review, int? page, string reviewStars, string sub)
        {
            ViewBag.ClientFeedback = null;
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(review))
            {
                var rating = string.IsNullOrEmpty(reviewStars) ? 0 : int.Parse(reviewStars);
                AddReviews.Add(name,review, rating );
            }
            else if(sub == "1")
            {
                ViewBag.ClientFeedback = "вы не заполнили поля!";
            }

                using (_db)
            {
                
                foreach (var i in _db.Reviews.OrderByDescending(c=>c.DateFeedback))
                {
                    _allReviewses.Add(i);
                }
            }
            int currentPageIndex = page ?? 1;
            
                _allReviewses = _allReviewses.ToPagedList(currentPageIndex, ReviewsPageSize);
            if (Request.IsAjaxRequest())
                    return PartialView("Feedback", (IPagedList<Reviews>) _allReviewses);
            return View(_allReviewses as List<Reviews>);
        }

    }
}