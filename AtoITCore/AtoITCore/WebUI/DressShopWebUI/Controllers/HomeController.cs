using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;
using static System.DateTime;


namespace DressShopWebUI.Controllers
{

    // контролер, для работы с основными страницами сайта, кроме админ - панели
    public class HomeController : Controller
    {
        private readonly ShopContext _db = new ShopContext(); //переменная контекста, по хорошему нужно еще и закрывать соединение с базой, подумаю...


        public ViewResult Index()// Стартовая страница 
        {
            DbSet<Photo> product = _db.Photo;
            if (!product.Any()) // проверка на наличие БД и записей.
                DebugDb.AddToDb();// Если БД пустая - заполнит "тестовыми значениями"
            // выборка фотографий в слайдер
            IQueryable<Photo> photo = from s in _db.Photo where s.Priority == true select s;
            return View(photo.ToList());
        }


        public ActionResult Selling()// страница каталога (ONLINE-гардероб) в разработке!!!!
        {
            
            //выбираем товары по категории  - 1
            var selling = from a in _db.Photo
                          where a.Product.Category == 1
                          orderby a.Product.DateCreate descending
                          select a;
            return View(selling.ToList());
        }


        public ActionResult Gallery() // страница Галерея
        {
            // выбираем фотографии по приоритету, и по категории 2
            var photo = from a in _db.Photo
                        where a.Priority == true
                        where a.Product.Category == 2
                        orderby a.Product.DateCreate descending
                        select a;
            return View(photo.ToList());
        }


        public ActionResult Partners() // страница Партнеры - в разработке!!!!
        {
            IOrderedQueryable<Photo> partners = from a in _db.Photo
                           where a.Product.Category == 3
                           orderby a.Product.DateCreate descending
                           select a;
           return View(partners.ToList());
        }


        public ActionResult ClientFeedback(string name, string review, string reviewStars) //страница Отзывы
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
            var reviews = from i in _db.Reviews
                    orderby i.DateFeedback descending 
                    select i;
            

            return View(reviews.ToList());
        }


        
    }
}