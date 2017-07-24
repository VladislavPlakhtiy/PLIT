using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private static readonly ShopContext Db = new ShopContext(); //переменная контекста, по хорошему нужно еще и закрывать соединение с базой, подумаю...

        //Формируем список фотографий для слайдера и передаем его в _Layout
        public static readonly IQueryable<Photo> Photo = from s in Db.Photo where s.Priority == true select s;
        public static readonly List<Photo> SliderPhoto = Photo.ToList(); 


        public ViewResult Index()// Стартовая страница 
        {
            DbSet<Photo> product = Db.Photo;
            if (!product.Any()) // проверка на наличие БД и записей.
                DebugDb.AddToDb();// Если БД пустая - заполнит "тестовыми значениями"
            return View();
        }


        public ActionResult Selling()// страница каталога (ONLINE-гардероб) в разработке!!!!
        {
            
            //выбираем товары по категории  - 1
            var selling = from s in Db.Photo
                          where s.Product.Category ==1
                          orderby s.Product.DateCreate descending
                          select s;
            return View(selling.ToList());
        }


        public ActionResult Gallery() // страница Галерея
        {
            // выбираем фотографии по приоритету, и по категории 2
            var photo = from s in Db.Photo
                        where s.Product.Category == 2
                        orderby s.Product.DateCreate descending
                        select s;
            return View(photo.ToList());
        }


        public ActionResult Partners() // страница Партнеры - в разработке!!!!
        {
            var partners = from s in Db.Photo
                           where s.Product.Category == 3
                           orderby s.Product.DateCreate descending
                           select s;
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
                    Db.Reviews.Add(new Reviews
                    {
                        ClientName = name,
                        ClientFeedback = review,
                        Rating = rating,
                        DateFeedback = Now
                    });
                    Db.SaveChanges();
                }
            var reviews = from i in Db.Reviews
                    orderby i.DateFeedback descending 
                    select i;
            

            return View(reviews.ToList());
        }

    }
}