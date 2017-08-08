using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Класс для отправки писем на почту
    /// </summary>
    public class EmailSending
    {
        /// <summary>
        /// метод для формирования тела письма Администратору
        /// </summary>
        public static string EmailMessageToAdministrator(BasketViewModel basketViewModel, Basket basket)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendLine("Добрый день!");
            str.AppendLine("Вам с сайта samarskaya.com поступил новый заказ!");
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Заказанные товары:");
            str.AppendLine("");
            foreach (var i in basket.Lines)
            {
                string category = i.Product.Category== "Selling" ? "ONLINE-гардероб": "Партнерское";

                var prise = i.Product.Discount != 0 ? $" (с учетом скидки) {i.Product.Price - i.Product.Price * i.Product.Discount / 100}" : $"{i.Product.Price}";
                str.AppendFormat($" Платье -  \"{i.Product.Name}\"  стоимостью - {prise} грн. (из категории - \"{category})\" ");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Подробности заказа:");
            str.AppendFormat($"Имя покупателя - {basketViewModel.Orders.ClientName}");
            str.AppendLine("");
            str.AppendFormat($"E-mail покупателя - {basketViewModel.Orders.Email}");
            str.AppendLine("");
            str.AppendFormat($"Телефон покупателя - {basketViewModel.Orders.Phone}");
            str.AppendLine("");
            str.AppendFormat($"Доставка - {basketViewModel.Orders.Delivery}");
            str.AppendLine("");
            str.AppendFormat($"Оплата - {basketViewModel.Orders.Payment}");
            str.AppendLine("");
            if (!string.IsNullOrEmpty(basketViewModel.Orders.Address))
            {
                str.AppendLine($"Адрес - {basketViewModel.Orders.Address}");
                str.AppendLine("");
            }
            if (!string.IsNullOrEmpty(basketViewModel.Orders.Сomment))
            {
                str.AppendLine($"Комментарий к заказу - {basketViewModel.Orders.Сomment}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendLine("");
            str.AppendFormat("Дата заказа -  {0:U}", basketViewModel.Orders.DateOrder );
            return str.ToString();
        }

        /// <summary>
        /// Отправка письма администратору
        /// </summary>
        public static void SendMailToAdministrator(BasketViewModel basketViewModel, Basket basket, string attachFile = null)
        {
            try
            {
                //c какой почты отправляем письмо 
                MailMessage mail = new MailMessage {From = new MailAddress("test-samarskaya@test.com") };
                mail.To.Add(new MailAddress("test-samarskaya-admin@test.com")); // E-mail Администратора
                mail.Subject = "Новый заказ";
                mail.Body = EmailMessageToAdministrator(basketViewModel, basket);
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    //c какой почты отправляем письмо + пароль от этой почты
                    Credentials = new NetworkCredential("test-samarskaya@test.com".Split('@')[0], "123456789"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mail);
                mail.Dispose();
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// формирование текста письма для пользователя
        /// </summary>
        public static string EmailMessage(BasketViewModel basketViewModel, Basket basket)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendFormat($"Добрый день, {basketViewModel.Orders.ClientName}!");
            str.AppendLine("");
            str.AppendLine("Благодарим Вас за покупку на сайте - samarskaya.com !");
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Детали заказа:");
            str.AppendLine("");
            foreach (var i in basket.Lines)
            {
                var prise = i.Product.Discount != 0 ? $" (с учетом скидки) {i.Product.Price - i.Product.Price * i.Product.Discount / 100}" : $"{i.Product.Price}";
                str.AppendFormat($" Заказанное платье -  \"{i.Product.Name}\"  стоимостью - {prise} грн.");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendFormat($"Общая сумма заказа - {basket.ComputeTotalValue()} грн.");
            str.AppendLine("");
            str.AppendLine("");
            
            str.AppendFormat($"выбранная Вами доставка - {basketViewModel.Orders.Delivery}");
            str.AppendLine("");
            str.AppendFormat($"выбранная Вами форма оплаты - {basketViewModel.Orders.Payment}");
            str.AppendLine("");
            if (!string.IsNullOrEmpty(basketViewModel.Orders.Address))
            {
                str.AppendLine($"Адрес доставки - {basketViewModel.Orders.Address}");
                str.AppendLine("");
            }
            if (!string.IsNullOrEmpty(basketViewModel.Orders.Сomment))
            {
                str.AppendLine($"Ваш комментарий - {basketViewModel.Orders.Сomment}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendFormat("Дата заказа -  {0:U}", basketViewModel.Orders.DateOrder);
            str.AppendLine("");
            str.AppendLine("Заказ отправлен в обработку, скоро мы с вами свяжемся, хорошего вам дня!");
            
            return str.ToString();
        }

        /// <summary>
        /// ОТПРАВКА ПИСЬМА ПОЛЬЗОВАТЕЛЮ
        /// </summary>
        public static void SendMail(BasketViewModel basketViewModel, Basket basket, string attachFile = null)
        {
            try
            {
                //c какой почты отправляем письмо
                MailMessage mail = new MailMessage {From = new MailAddress("test-samarskaya@test.com") };
                mail.To.Add(new MailAddress(basketViewModel.Orders.Email)); //получаем E-mail который ввел пользователь
                mail.Subject = "samarskaya.com"; // тема письма
                mail.Body = EmailMessage(basketViewModel, basket);
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com", //Хост
                    Port = 587,//Порт
                    EnableSsl = true,
                    //c какой почты отправляем письмо + пароль от этой почты
                    Credentials = new NetworkCredential("test-samarskaya@test.com".Split('@')[0], "123456789"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mail);
                mail.Dispose();
                basket.AnswerList.Add($"Уважаемый(ая), {basketViewModel.Orders.ClientName}! ");
                basket.AnswerList.Add("Благодарим Вас за покупку!");
                basket.AnswerList.Add($"На Ваш E-mail ({basketViewModel.Orders.Email}) высланы все детали заказа.");
                basket.AnswerList.Add("Заказ отправлен в обработку, скоро мы с вами свяжемся, хорошего вам дня!");
            }
            catch (Exception)
            {
                basket.AnswerList.Clear();
                basket.AnswerList.Add($"Что то пошло не так, мы не смогли отправить письмо на Ваш E-mail ({basketViewModel.Orders.Email}) ");
                basket.AnswerList.Add("");
                basket.AnswerList.Add("Просим прощения, за технические неполадки.");
            }
        }
    }
}