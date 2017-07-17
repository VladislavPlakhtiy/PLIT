using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;
using MvcPaging;
using static System.DateTime;


namespace DressShopWebUI.Controllers
{
    
    // контролер, для работы с основными страницами сайта, кроме админ - панели
    public class HomeController : Controller
    {
        private readonly ShopContext _db = new ShopContext(); //переменная контекста, по хорошему нужно еще и закрывать соединение с базой, подумаю...
        private const int ReviewsPageSize = 5; //количество отзывов на странице.
        private const int GalleryPageSize = 10; // количество фото на станице Галерея
        private const int SellingPageSize = 10; // количество продуктов на станице ONLINE-гардероб
        //переменные
        private IList<Reviews> _allReviewses = new List<Reviews>();
        private IList<Photo> _allGallery = new List<Photo>();
        private IList<Photo> _allSelling = new List<Photo>();

        // Стартовая страница
        public ViewResult Index()
        {
            DbSet<Photo> product = _db.Photo;
            if (!product.Any()) // проверка на наличие БД и записей.
                DebugDb.AddToDb();
            // выборка фотографий в слайдер
            IQueryable<Photo> photo = from s in _db.Photo where s.Priority == true select s; 
            return View(photo.ToList());
        }

        // страница каталога (ONLINE-гардероб)
        public ActionResult Selling(int? page)
        {

            int currentPageIndex = page ?? 1; //выбираем страницу
            //выбираем категорию  - 1
            var selling = from a in _db.Photo 
                where a.Product.Category == 1
                orderby a.Product.DateCreate descending
                select a;

            foreach (var i in selling)
            {
                _allSelling.Add(i);
            }
            //вибираем продукты для отображения на странице (по константе SellingPageSize)
            int count = 0;
            int countProduct = 0;
            foreach (var i in _allSelling)
            {
                count++;
                if (i.Priority == true)
                    countProduct++;
                if (countProduct ==SellingPageSize)
                break;
            }
            _allSelling = _allSelling.ToPagedList(currentPageIndex, count);
            if (Request.IsAjaxRequest()) // возвращаем частичное представление, если Ajax запрос
                return PartialView("PartialSelling", (IPagedList<Photo>)_allSelling);
            return View(_allSelling as List<Photo>);
        }


        // страница Галерея
        public ActionResult Gallery(int? page)
        {
            int currentPageIndex = page ?? 1;
            // выбираем фотографии по приоритету, и по категории 2
                var photo = from a in _db.Photo
                            where a.Priority == true
                            where a.Product.Category == 2
                            orderby a.Product.DateCreate descending
                            select a;

                foreach (var i in photo)
                {
                    _allGallery.Add(i);
                }
            _allGallery = _allGallery.ToPagedList(currentPageIndex, GalleryPageSize);
            if (Request.IsAjaxRequest())
                return PartialView("PartialGallery", (IPagedList<Photo>)_allGallery);
            return View(_allGallery as List<Photo>);
        }

        // страница Партнеры
        public ActionResult Partners()
        {

            return View();
        }

        //страница Отзывы
        public ActionResult ClientFeedback(string name, string review, int? page, string reviewStars)
        {
            using (_db) //обращаемся к БД
            {
                //проверяем наличие Имени и Отзыва
                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(review))
                {
                    //проверяем наличие рейтинга заполненого пользователем.
                    var rating = string.IsNullOrEmpty(reviewStars) ? 0 : int.Parse(reviewStars);
                    // добавляем запись в БД
                    _db.Reviews.Add(new Reviews
                    {
                        ClientName = name,
                        ClientFeedback = review,
                        Rating = rating,
                        DateFeedback = Now
                    });
                    _db.SaveChanges();
                }
                //сортируем по дате отзывы, и добавляем в переменную
                foreach (var i in _db.Reviews.OrderByDescending(c => c.DateFeedback))
                {
                    _allReviewses.Add(i);
                }
            }
            int currentPageIndex = page ?? 1;

            _allReviewses = _allReviewses.ToPagedList(currentPageIndex, ReviewsPageSize);
            if (Request.IsAjaxRequest())
                return PartialView("Feedback", (IPagedList<Reviews>)_allReviewses);
            return View(_allReviewses as List<Reviews>);
        }

    }
}