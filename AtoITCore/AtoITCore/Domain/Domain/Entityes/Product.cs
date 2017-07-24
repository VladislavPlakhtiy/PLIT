using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entityes
{

    /// <summary>
    /// Сущьность продукта повставлял элементы валидации, пока не знаю, нужны ли будут.
    /// </summary>
    public sealed class Product
    {
        public Product()
        {
            Photo = new HashSet<Photo>();
        }
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Display(Name = "Название товара")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Скидка")]
        [Range(typeof(int), "0", "100", ErrorMessage = "Пожалуйста, введите корректную скидку в процентах")]
        public int Discount { get; set; }

        [Display(Name = "Специальное предложение")]
        public string SpecOffer { get; set; }

        [Display(Name = "Цена(грн)")]
        [Required(ErrorMessage = "Пожалуйста, введите цену товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите корректную цену")]
        public decimal Price { get; set; }

        [Display(Name = "Дата добавления товара")]
        [Required]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию")]
        [Range(typeof(int), "1", "10")]
        public int Category { get; set; }


        public ICollection<Photo> Photo { get; set; }

        // public Orders Orders { get; set; }
        //public int? OrdersProductId { get; set; }
        // public Category Category { get; set; }
    }
}
