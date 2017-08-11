using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class OrderDetails
    {
        //public virtual ICollection<Product> Product { get; set; }

        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина имени от 3 до 20 символов")]
        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя")]
        public string ClientName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Введите свой E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Display(Name = "Доставка")]
        [Required(ErrorMessage = "Вы не выбрали способ доставки")]
        public string Delivery { get; set; }

        [Display(Name = "Оплата")]
        [Required(ErrorMessage = "Вы не выбрали способ оплаты")]
        public string Payment { get; set; }

        [Display(Name = "Адресс")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина текста от 3 до 500 символов")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Номер телефона не корректен!")]
        public string Phone { get; set; }

        [Display(Name = "Комментарий")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина текста от 3 до 500 символов")]
        public string Сomment { get; set; }

        [Display(Name = "Дата заказа")]
        [Required]
        public DateTime DateOrder => DateTime.Now;
    }
}
