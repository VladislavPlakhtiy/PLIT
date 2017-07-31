using System.Web.Mvc;
using DressShopWebUI.Authentication;

namespace DressShopWebUI.Controllers
{
    /// <summary>
    /// Контроллер для аунтификации администратора
    /// </summary>
    public class MyController : Controller
    {
        
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (FormAuthProvider.Authenticate(model.Name, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("MyPanel", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
