using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entityes
{

    /// <summary>
    /// Сущьность продукта
    /// </summary>
    public class Product
    {
        public Product()
        {
            //Photo = new HashSet<Photo>();
        }
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Display(Name = "Название товара")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина названия от 3 до 50 символов")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина описания от 3 до 500 символов")]
        public string Description { get; set; }

        [Display(Name = "Скидка")]
        [Required(ErrorMessage = "Если товар не содержит скидок введите - 0")]
        [Range(typeof(int), "0", "99", ErrorMessage = "Пожалуйста, введите корректную скидку в процентах (0-99)")]
        public int Discount { get; set; }

        [Display(Name = "Специальное предложение")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Длина спец. предложения от 3 до 250 символов")]
        public string SpecOffer { get; set; }

        [Display(Name = "Цена(грн)")]
        [Required(ErrorMessage = "Пожалуйста, введите цену товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите корректную цену")]
        public double Price { get; set; }

        [Display(Name = "Дата добавления товара")]
        [Required]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию")]
        public string Category { get; set; }


        public virtual ICollection<Photo> Photo { get; set; }
        
    }
}
