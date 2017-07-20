using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DressShopWebUI.Models;

namespace DressShopWebUI.Controllers
{
    // Действия с корзиной, пока кидаю один метод, потом расширю
    public class BasketController : Controller
    {
        // Покупка. пока оставляю так просто для view, позже это будет просто метод к кнопке в страницу Гардероб
        public ActionResult Buy(int id ,string name)
        {
            ViewBag.Name =name;
            return View();
        }
    }
}