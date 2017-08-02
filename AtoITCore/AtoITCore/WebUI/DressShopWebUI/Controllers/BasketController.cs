using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entityes;
using DressShopWebUI.Models;

namespace DressShopWebUI.Controllers
{
    // Действия с корзиной, пока кидаю один метод, потом расширю
    public class BasketController : Controller
    {
        private static readonly ShopContext Db = new ShopContext();
        
        //отображение корзины
        public ViewResult Index(Basket basket, string returnUrl)
        {
            var userBasket = new BasketViewModel
            {
                Basket = basket,
                ReturnUrl = returnUrl
            };
            if (userBasket.Basket.CountItem==0)
            {
                ViewBag.Sorry = "Ваша корзина пуста";
            }
            return View(userBasket);

        }

        // POST метод, оформления заказа
        [HttpPost]
        public ActionResult Index( BasketViewModel basketViewModel, Basket basket, string returnUrl)
        {
            //проверяем валидность модели, и наличие товаров в корзине
            if (ModelState.IsValid && basket.CountItem!=0)
            {
                //todo
                EmailSending.SendMailToAdministrator(basketViewModel, basket);
                EmailSending.SendMail(basketViewModel, basket); // пока не работает
                return RedirectToAction("Thanks","Basket");
            }
           
            return Index(basket,returnUrl);
        }

        //Благодарности за покупку
        public ViewResult Thanks(Basket basket)
        {
            ViewBag.Answer = basket.AnswerList.ToList();
            basket.Clear();
            return View();
        }

        //Метод добавления товаров в корзину
        public RedirectToRouteResult AddToBasket(Basket basket, int photoId, string returnUrl)
        {
             Photo photo = Db.Photo
                .FirstOrDefault(b => b.PhotoId == photoId);

            if (photo != null)
            {
                basket.AddProduct(photo);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //Метод удаления товаров из корзины
        public RedirectToRouteResult RemoveFromBasket(Basket basket, int photoId, string returnUrl)
        {
            Photo photo = Db.Photo
               .FirstOrDefault(b => b.PhotoId == photoId);

            if (photo != null)
            {
                basket.RemoveProduct(photo);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //Частичное представления для _Layout
        public PartialViewResult Summary(Basket basket)
        {
            return PartialView(basket);
        }
        //Частичное представления для Selling и Partners (плавающая корзина)
        public PartialViewResult BasketOnView(Basket basket)
        {
            return PartialView(basket);
        }
    }

}