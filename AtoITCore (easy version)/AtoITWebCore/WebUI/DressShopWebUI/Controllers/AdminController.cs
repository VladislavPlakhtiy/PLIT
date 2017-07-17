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
        // Админка - вход (чуть позже запаролим)
        public ViewResult MyPanel()
        {
            return View();
        }
    }
}