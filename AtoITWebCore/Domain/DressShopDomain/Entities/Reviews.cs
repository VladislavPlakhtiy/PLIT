using System;
using System.ComponentModel.DataAnnotations;

namespace DressShopDomain.Entities
{
    /// <summary>
    /// Сущьность для таблицы отзывов
    /// </summary>
    public class Reviews
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Имя коментатора")]
        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя")]
        public string ClientName { get; set; }

        [Display(Name = "Отзыв")]
        [Required(ErrorMessage = "Отзыв не может быть пуст")]
        public string ClientFeedback { get; set; }

        [Display(Name = "Рейтинг")]
        public int RatingType { get; set; }

        [Display(Name = "Дата отзыва")]
        [Required]
        public DateTime DateFeedback { get; set; }
    }
}
