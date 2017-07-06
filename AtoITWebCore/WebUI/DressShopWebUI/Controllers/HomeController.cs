using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace DressShopWebUI.Controllers
{
    public class HomeController : Controller
    {
        
        // Стартовая страница
        public ViewResult Index()
        {
            
            return View();
        }
        // страница каталога (ONLINE-гардероб)
        public ViewResult DressingRoom()
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