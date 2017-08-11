using System.Linq;
using System.Web.Mvc;
using Domain.Abstrac;
using Domain.Entityes;


namespace DressShopWebUI.Controllers
{

    // контролер, для работы с основными страницами сайта, кроме админ - панели
    public class HomeController : Controller
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IProductRepository _productRepository;
        //Объявляем зависимость контроллера от хранилища сущностей
        public HomeController(IProductRepository productRepository,  IReviewsRepository reviewsRepo)
        {
            _productRepository = productRepository;
            _reviewsRepository = reviewsRepo;
        }

        // Стартовая страница "о дизайнере"
        public ViewResult Index()
        {
            return View();
        }

        //генирация слайдера
        public ActionResult Slider()  
        {
            return PartialView(_productRepository.Products.ToList());
        }

        // страница каталога (ONLINE-гардероб)
        public ActionResult Selling()
        {
            //выбираем товары по категории  "Selling"
            return View(_productRepository.Products.
                Where(x => x.Category == "Selling").
                OrderByDescending(x => x.DateCreate));
        }

        // страница Галерея
        public ActionResult Gallery() 
        {
            // выбираем фотографии по приоритету, и по категории "Gallery"
            return View(_productRepository.Products.
                Where(x => x.Category == "Gallery").
                OrderByDescending(x => x.DateCreate));
        }

        // страница Партнеры 
        public ActionResult Partners() 
        {
            //выбираем товары по категории  "Partners"
            return View(_productRepository.Products.
                Where(x => x.Category == "Partners").
                OrderByDescending(x => x.DateCreate));
        }

        #region Отзывы

        public ViewResult ClientFeedback() //стартовая страница Отзывы
        {
            return View(_reviewsRepository.Reviewses.OrderByDescending(x => x.DateFeedback));
        }

        [HttpPost]
        public ActionResult Feedback(Reviews model) //метод добавляющий запись в БД
        {
            //проверяем валидность согласно модели
            if (ModelState.IsValid)
            {
                _reviewsRepository.SaveReview(model);
                TempData["messageOk"] = "Благодарим Вас за отзыв!";
                return Redirect("/Home/ClientFeedback");
            }
            TempData["message"] = "Отзыв не был добавлен - проверьте правильность заполнения формы отзыва!";
            return Redirect("/Home/ClientFeedback");
        }
        #endregion

    }
}