using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entityes;

namespace DressShopWebUI.Models
{
    public class Orders
    {
        public Orders()
        {
            Product = new HashSet<Photo>();
        }
        
        public ICollection<Photo> Product { get; set; }


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

        [Display(Name = "Комментарий")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина текста от 3 до 500 символов")]
        public string Сomment { get; set; }

        [Display(Name = "Дата заказа")]
        [Required]
        public DateTime DateOrder => DateTime.Now;
    }
}