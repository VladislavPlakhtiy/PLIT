using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;
using PagedList.Mvc;
using PagedList;


namespace DressShopWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _db = new ShopContext();
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
        // страница Отзывы (в разработке!!!!)
        [HttpGet]
        public ViewResult ClientFeedback(int? page)
        {
            IQueryable<Reviews> reviewses = _db.Reviews;
            if (!reviewses.Any())
                DebugDb.AddToDb();
            int numberOfReviews = 3;
            int pageNumber = page ?? 1;
            reviewses = reviewses.OrderBy(c => c.DateFeedback);
            return View(reviewses.ToList().ToPagedList(pageNumber, numberOfReviews));
        }

        [HttpPost]
        public PartialViewResult ClientFeedback(string userName, string userFeedback, int raiting, int? page)
        {
            IQueryable<Reviews> reviewses = _db.Reviews;
            reviewses = reviewses.OrderBy(c => c.DateFeedback);
            int numberOfReviews = 3;
            int pageNumber = page ?? 1;
            return PartialView("ClientFeedbackList",reviewses.ToList().ToPagedList(pageNumber, numberOfReviews));
        }

    }
}