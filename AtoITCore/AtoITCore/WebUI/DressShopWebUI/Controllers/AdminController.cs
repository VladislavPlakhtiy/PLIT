using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressShopWebUI.Controllers
{
    /// <summary>
    /// Контроллер для админ - панели
    /// </summary>
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult MyPanel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyPanel(string name, string password)
        {
            if (name != "admin" && password != "admin")
            {
                ViewBag.Answer = "Вы ввели не верные данные!";
                return View();
            }
            else
            {
                return View("AdminView");
            }
        }
    }
}