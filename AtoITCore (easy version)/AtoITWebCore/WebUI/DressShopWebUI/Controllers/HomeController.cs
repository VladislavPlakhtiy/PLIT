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
        private const int PartnersPageSize = 10; // количество продуктов на станице Партнеры
        
        
        public ViewResult Index()// Стартовая страница 
        {
            DbSet<Photo> product = _db.Photo;
            if (!product.Any()) // проверка на наличие БД и записей.
                DebugDb.AddToDb();
            // выборка фотографий в слайдер
            IQueryable<Photo> photo = from s in _db.Photo where s.Priority == true select s; 
            return View(photo.ToList());
        }

        
        public ActionResult Selling(int? page)// страница каталога (ONLINE-гардероб) в разработке!!!!
        {

            int currentPageIndex = page ?? 1; //выбираем страницу
            IList<Photo> allSelling = new List<Photo>();
        //выбираем категорию  - 1
        var selling = from a in _db.Photo 
                where a.Product.Category == 1
                orderby a.Product.DateCreate descending
                select a;

            foreach (var i in selling)
            {
                allSelling.Add(i);
            }
            //вибираем продукты для отображения на странице (по константе SellingPageSize)
            int count = 0;
            int countProduct = 0;
            foreach (var i in allSelling)
            {
                count++;
                if (i.Priority == true)
                    countProduct++;
                if (countProduct ==SellingPageSize)
                break;
            }
            allSelling = allSelling.ToPagedList(currentPageIndex, count);
            if (Request.IsAjaxRequest()) // возвращаем частичное представление, если Ajax запрос
                return PartialView("PartialSelling", (IPagedList<Photo>)allSelling);
            return View(allSelling as List<Photo>);
        }

        public ActionResult Gallery(int? page) // страница Галерея
        {
            int currentPageIndex = page ?? 1;
            IList<Photo> allGallery = new List<Photo>();
        // выбираем фотографии по приоритету, и по категории 2
        var photo = from a in _db.Photo
                            where a.Priority == true
                            where a.Product.Category == 2
                            orderby a.Product.DateCreate descending
                            select a;

                foreach (var i in photo)
                {
                    allGallery.Add(i);
                }
            allGallery = allGallery.ToPagedList(currentPageIndex, GalleryPageSize);
            if (Request.IsAjaxRequest())
                return PartialView("PartialGallery", (IPagedList<Photo>)allGallery);
            return View(allGallery as List<Photo>);
        }

       
        public ActionResult Partners(int? page) // страница Партнеры - в разработке!!!!
        {
            int currentPageIndex = page ?? 1;
            IList<Product> allPartners = new List<Product>();
            using (_db)
            {
                foreach (var product in _db.Product.OrderByDescending(c=>c.DateCreate).Where(c=>c.Category==3))
                    allPartners.Add(product);
            }
            allPartners = allPartners.ToPagedList(currentPageIndex, PartnersPageSize);
            if (Request.IsAjaxRequest()) // возвращаем частичное представление, если Ajax запрос
                return PartialView("PartialPartners", (IPagedList<Product>)allPartners);
            return View(allPartners as List<Product>);
        }

       
        public ActionResult ClientFeedback(string name, string review, int? page, string reviewStars) //страница Отзывы
        {
             IList<Reviews> allReviewses = new List<Reviews>();
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
                    allReviewses.Add(i);
                }
            }
            int currentPageIndex = page ?? 1;

            allReviewses = allReviewses.ToPagedList(currentPageIndex, ReviewsPageSize);
            if (Request.IsAjaxRequest())
                return PartialView("Feedback", (IPagedList<Reviews>)allReviewses);
            return View(allReviewses as List<Reviews>);
        }

    }
}