using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressShopWebUI.Controllers
{
    // Действия с корзиной, пока кидаю один метод, потом расширю
    public class BasketController : Controller
    {
        // Покупка. пока оставляю так просто для view, позже это будет просто метод к кнопке в страницу Гардероб
        public ViewResult Buy()
        {
            return View();
        }
    }
}