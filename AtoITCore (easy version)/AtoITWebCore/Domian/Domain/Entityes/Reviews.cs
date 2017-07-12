using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class Reviews
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ReviewId { get; set; }

        [Display(Name = "Имя коментатора")]
        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя")]
        public string ClientName { get; set; }

        [Display(Name = "Отзыв")]
        [Required(ErrorMessage = "Отзыв не может быть пуст")]
        public string ClientFeedback { get; set; }

        [Display(Name = "Рейтинг")]
        public int? Rating { get; set; }

        [Display(Name = "Дата отзыва")]
        [Required]
        public DateTime DateFeedback { get; set; }
    }
}
