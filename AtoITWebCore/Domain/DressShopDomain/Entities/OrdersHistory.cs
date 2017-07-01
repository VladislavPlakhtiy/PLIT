using System;
using System.ComponentModel.DataAnnotations;

namespace DressShopDomain.Entities
{
    /// <summary>
    /// сущность для таблицы история покупок.
    /// </summary>
    public class OrdersHistory
    {
        // На данный момент, для магазина платьев не нужен раздел в админке - история покупок. Но сущьность пусть будет, мало ли...
        // Поэтому будим использовать только нужные нам поля формы отправки письма заказщику и покупателю
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int Id { get; set; }


        [Display(Name = "Сумма покупки")]
        public decimal Sum { get; set; }


        [Display(Name = "Выбор способа доставки")]
        [Required(ErrorMessage = "Пожалуйста, выберите способ доставки")] //Самовывоз, Новая почта, Укрпочта.
        [Range(typeof(int), "1", "10")] // ограничение для выпадающего списка (если будет именно списком), если будет пустое поле (значение - 0)
        public int Delivery { get; set; }


        //Имя, фамилия покупателя, сделал одним полем.
        [Display(Name = "Имя и фамилия клиента")]
        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя и фамилию")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Вы ввели некорректное Имя и Фамилию")]
        public string ClientName { get; set; }


        [Display(Name = "E-mail клиента")]
        [Required(ErrorMessage = "Пожалуйста, укажите Ваш E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Вы ввели некорректный адрес")]
        public string Email { get; set; }


        [Display(Name = "Номер телефона клиента")]
        [Required(ErrorMessage = "Пожалуйста, укажите номер Вашего телефона")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Вы ввели некорректный номер телефона")]
        public string Phone { get; set; }


        [Display(Name = "Город для доставки")]
        public string Sity { get; set; }

        
        [Display(Name = "Коментарий покупателя к покупке")]
        public string Comments  { get; set; }

        
        [Display(Name = "Время составления заказа")]
        [Required]
        public DateTime DateOrder { get; set; }


        //Статус заказа (в обработке, офрмлен, отменен)
        [Display(Name = "Статус заказа")]
        public int Status { get; set; }
    }
}
