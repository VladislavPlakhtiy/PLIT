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
    [Authorize]
    public class AdminController : Controller
    {
        /// <summary>
        /// Стартовая страница Админ-панели
        /// </summary>
        /// <returns></returns>
        public ActionResult MyPanel()
        {
            return View();
        }

        /// <summary>
        /// добавления товара
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct()
        {
            return View();
        }

        /// <summary>
        /// Список отзывов
        /// </summary>
        /// <returns></returns>
        public ActionResult EditingReviews()
        {
            return View();
        }
    }
}