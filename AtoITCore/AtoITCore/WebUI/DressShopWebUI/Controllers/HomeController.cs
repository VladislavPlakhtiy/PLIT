﻿using System.Collections.Generic;
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


        public ActionResult Selling(int page = 1)// страница каталога (ONLINE-гардероб) в разработке!!!!
        {
            
            //выбираем товары по категории  - 1
            var selling = from a in _db.Photo
                          where a.Product.Category == 1
                          orderby a.Product.DateCreate descending
                          select a;
            int size = 4; // количество объектов на страницу
            int pageSize = CountItem(selling.ToList(), size); //расчитываем исходя из продуктов а не из фото
            IEnumerable<Photo> sell =selling.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = selling.Count() };
            SellingViewModel ivm = new SellingViewModel { PageInfo = pageInfo, Photo = sell };
            return View(ivm);
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


        public ActionResult Partners(int page = 1) // страница Партнеры - в разработке!!!!
        {
            var partners = from a in _db.Photo
                           where a.Product.Category == 3
                           orderby a.Product.DateCreate descending
                           select a;
            int size = 4; // количество объектов на страницу
            int pageSize = CountItem(partners.ToList(), size); //расчитываем исходя из продуктов а не из фото
            IEnumerable<Photo> sell = partners.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = partners.Count() };
            PartnersViewModel ivm = new PartnersViewModel { PageInfo = pageInfo, Photo = sell };
            return View(ivm);
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

        /// <summary>
        /// Вспомогательный метод, для расщета количества элементов на странице по константе
        /// </summary>
        /// <param name="mas">Массив фотографий</param>
        /// <param name="pageSize"> Количество продуктов на странице</param>
        /// <returns></returns>
        private int CountItem(IList<Photo> mas, int pageSize)
        {
            int count = 0;
            int countProduct = 0;
            int id = 0;
            foreach (var i in mas)
            {

                if (id.Equals(0) || id.Equals(i.Product.ProductId))
                {
                    id = i.Product.ProductId;
                    count++;
                }
                else
                {
                    if (countProduct == pageSize - 1)
                        break;
                    countProduct++;
                    count++;
                    id = i.Product.ProductId;

                }
            }
            return count;
        }
    }
}