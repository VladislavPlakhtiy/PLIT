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
        private static readonly ShopContext Db = new ShopContext(); //переменная контекста, по хорошему нужно еще и закрывать соединение с базой, подумаю...

        //Формируем список фотографий для слайдера и передаем его в _Layout
        public static readonly IQueryable<Photo> Photo = from s in Db.Photo where s.Priority == true select s;
        public static readonly List<Photo> SliderPhoto = Photo.ToList();


        public ViewResult Index()// Стартовая страница 
        {
            return View();
        }


        public ActionResult Selling()// страница каталога (ONLINE-гардероб)
        {

            //выбираем товары по категории  - 1
            var selling = from s in Db.Photo
                          where s.Product.Category == 1
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


        public ActionResult Partners() // страница Партнеры 
        {
            var partners = from s in Db.Photo
                           where s.Product.Category == 3
                           orderby s.Product.DateCreate descending
                           select s;
            return View(partners.ToList());
        }


        public ActionResult ClientFeedback() //страница Отзывы
        {

            var reviews = from s in Db.Reviews
                          orderby s.DateFeedback descending
                          select s;

            ViewBag.Review = reviews.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(Reviews model) //метод добавляющий запись в БД
        {
            //проверяем валидность согласно модели
            if (ModelState.IsValid)
            {
                //проверяем наличие рейтинга заполненого пользователем.
                var rating = string.IsNullOrEmpty(model.Rating.ToString()) ? 0 : int.Parse(model.Rating.ToString());
                // добавляем запись в БД
                Db.Reviews.Add(new Reviews
                {
                    ClientName = model.ClientName,
                    ClientFeedback = model.ClientFeedback,
                    Rating = rating,
                    Email = model.Email,
                    Advantages = model.Advantages,
                    LackOf = model.LackOf,
                    DateFeedback = Now
                });
                Db.SaveChanges();
            }
            return Redirect("/Home/ClientFeedback");
        }

    }
}