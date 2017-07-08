﻿using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;


namespace DressShopWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _db = new ShopContext();
            // Стартовая страница
        public ViewResult Index()
        {
            var product = _db.Photo;
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
        // страница Галерея
        public ViewResult Gallery()
        {
            return View();
        }
        // страница Партнеры
        public ViewResult Partners()
        {
            return View();
        }
        // страница Отзывы
        public ViewResult ClientFeedback()
        {
            return View();
        }
    }
}