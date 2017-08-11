using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Domain.Abstrac;
using Domain.Entityes;

namespace Domain.Concrete
{
    /// <summary>
    /// Класс для отправки писем на почту
    /// </summary>
    public class EmailSending : IEmailSending
    {
        /// <summary>
        /// Отправка письма администратору
        /// </summary>
        public  void SendMailToAdministrator(Basket basket, OrderDetails details, string attachFile = null)
        {
            try
            {
                //c какой почты отправляем письмо 
                MailMessage mail = new MailMessage { From = new MailAddress("test-samarskaya@test.com") };
                mail.To.Add(new MailAddress("test-samarskaya-admin@test.com")); // E-mail Администратора
                mail.Subject = "Новый заказ";
                mail.Body = EmailMessageToAdministrator(basket, details);
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
        /// ОТПРАВКА ПИСЬМА ПОЛЬЗОВАТЕЛЮ
        /// </summary>
        public void SendMail(Basket basket, OrderDetails details, string attachFile = null)
        {
            try
            {
                //c какой почты отправляем письмо
                MailMessage mail = new MailMessage { From = new MailAddress("test-samarskaya@test.com") };
                mail.To.Add(new MailAddress(details.Email)); //получаем E-mail который ввел пользователь
                mail.Subject = "samarskaya.com"; // тема письма
                mail.Body = EmailMessage(basket, details);
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
                basket.AnswerList.Add($"Уважаемый(ая), {details.ClientName}! ");
                basket.AnswerList.Add("Благодарим Вас за покупку!");
                basket.AnswerList.Add($"На Ваш E-mail ({details.Email}) высланы все детали заказа.");
                basket.AnswerList.Add("Заказ отправлен в обработку, скоро мы с вами свяжемся, хорошего вам дня!");
            }
            catch (Exception)
            {
                basket.AnswerList.Clear();
                basket.AnswerList.Add($"Что то пошло не так, мы не смогли отправить письмо на Ваш E-mail ({details.Email}) ");
                basket.AnswerList.Add("");
                basket.AnswerList.Add("Просим прощения, за технические неполадки.");
            }
        }

        /// <summary>
        /// формирование текста письма для пользователя
        /// </summary>
        public static string EmailMessage(Basket basket, OrderDetails details)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendFormat($"Добрый день, {details.ClientName}!");
            str.AppendLine("");
            str.AppendLine("Благодарим Вас за покупку на сайте - samarskaya.com !");
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Детали заказа:");
            str.AppendLine("");
            foreach (var i in basket.Lines)
            {
                var prise = i.Discount != 0 ? $" (с учетом скидки) {i.Price - i.Price * i.Discount / 100}" : $"{i.Price}";
                str.AppendFormat($" Заказанное платье -  \"{i.Name}\"  стоимостью - {prise} грн.");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendFormat($"Общая сумма заказа - {basket.ComputeTotalValue()} грн.");
            str.AppendLine("");
            str.AppendLine("");

            str.AppendFormat($"выбранная Вами доставка - {details.Delivery}");
            str.AppendLine("");
            str.AppendFormat($"выбранная Вами форма оплаты - {details.Payment}");
            str.AppendLine("");
            if (!string.IsNullOrEmpty(details.Address))
            {
                str.AppendLine($"Адрес доставки - {details.Address}");
                str.AppendLine("");
            }
            if (!string.IsNullOrEmpty(details.Сomment))
            {
                str.AppendLine($"Ваш комментарий - {details.Сomment}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendFormat("Дата заказа -  {0:U}", details.DateOrder);
            str.AppendLine("");
            str.AppendLine("Заказ отправлен в обработку, скоро мы с вами свяжемся, хорошего вам дня!");

            return str.ToString();
        }
        /// <summary>
        /// метод для формирования тела письма Администратору
        /// </summary>
        public static string EmailMessageToAdministrator(Basket basket, OrderDetails details)
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
                string category = i.Category == "Selling" ? "ONLINE-гардероб" : "Партнерское";

                var prise = i.Discount != 0 ? $" (с учетом скидки) {i.Price - i.Price * i.Discount / 100}" : $"{i.Price}";
                str.AppendFormat($" Платье -  \"{i.Name}\"  стоимостью - {prise} грн. (из категории - \"{category})\" ");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Подробности заказа:");
            str.AppendFormat($"Имя покупателя - {details.ClientName}");
            str.AppendLine("");
            str.AppendFormat($"E-mail покупателя - {details.Email}");
            str.AppendLine("");
            str.AppendFormat($"Телефон покупателя - {details.Phone}");
            str.AppendLine("");
            str.AppendFormat($"Доставка - {details.Delivery}");
            str.AppendLine("");
            str.AppendFormat($"Оплата - {details.Payment}");
            str.AppendLine("");
            if (!string.IsNullOrEmpty(details.Address))
            {
                str.AppendLine($"Адрес - {details.Address}");
                str.AppendLine("");
            }
            if (!string.IsNullOrEmpty(details.Сomment))
            {
                str.AppendLine($"Комментарий к заказу - {details.Сomment}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendLine("");
            str.AppendFormat("Дата заказа -  {0:U}", details.DateOrder);
            return str.ToString();
        }

    }
}
