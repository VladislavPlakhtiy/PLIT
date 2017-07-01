using System;
using System.ComponentModel.DataAnnotations;

namespace DressShopDomain.Entities
{
    /// <summary>
    /// сущность для таблици продуктов
    /// </summary>
    public class Product
    {
        //<summary> - коменты не пашут для сушьностей БД - не верите?) - проверьте, я сам офигел!
        [ScaffoldColumn(false)] //сокрытие поля для вывода во View
        [Display(Name = "ID")]
        public int DressId { get; set; }


        // Название 
        [Display(Name = "Название товара")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")] //Валидация
        public string Name { get; set; }


        //Описание
        [Display(Name = "Описание")]
        public string Description { get; set; }

        // Специальное предложение
        [Display(Name = "Специальное предложение")]
        public string SpecOffer { get; set; }


        // Цена
        [Display(Name = "Цена(грн)")]
        [Required(ErrorMessage = "Пожалуйста, введите цену товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите корректную цену")]
        public decimal Price { get; set; }


        // Категория 
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию")]
        [Range(typeof(int), "1", "10")] // ограничение для выпадающего списка (если будет именно списком), если будет пустое поле (значение - 0)
        public int Category { get; set; }


        //Дата добавления платья в БД
        [Display(Name = "Дата добавления")]
        [Required]
        public DateTime DateCreate { get; set; }


        //Количество товара
        [Display(Name = "Количество товара")]
        public int Quantity { get; set; }


        //Наличие товара
        [Display(Name = "Наличие товара в магазине")]
        public bool Existence { get; set; }


        //форент кей для базы - OrdersHistory
        [Display(Name = "Купленый товар")]
        public int OrdersHistoryId { get; set; }

    }
}
