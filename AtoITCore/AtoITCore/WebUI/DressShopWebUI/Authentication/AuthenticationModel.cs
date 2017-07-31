using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace DressShopWebUI.Authentication
{
    /// <summary>
    /// Модель для ввода нанных Администратора
    /// </summary>
    public class AuthenticationModel
    {
        
        [Required(ErrorMessage = "Пожалуйста, логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Получение доступа к контроллеру Admin
    /// </summary>
    public class FormAuthProvider 
    {
        public static bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            return result;
        }
    }
}