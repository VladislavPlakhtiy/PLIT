using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    /// <summary>
    /// Сущьность для формирование таблицы Отзывы.
    /// </summary>
    public class Reviews
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ReviewId { get; set; }

        [Display(Name = "Имя коментатора")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина имени от 3 до 20 символов")]
        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя")]
        public string ClientName { get; set; }

        [Display(Name = "Отзыв")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина отзывы от 3 до 1000 символов")]
        [Required(ErrorMessage = "Отзыв не может быть пуст")]
        public string ClientFeedback { get; set; }

        [Display(Name = "Рейтинг")]
        [Range(typeof(int), "0", "5", ErrorMessage = "Рейтинг вычисляется от 0 до 5")]
        public int? Rating { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Введите свой E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Display(Name = "Достоинства товара")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина текста от 3 до 500 символов")]
        public string Advantages { get; set; }

        [Display(Name = "Недостатки товара")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина текста от 3 до 500 символов")]
        public string LackOf { get; set; }

        [Display(Name = "Дата отзыва")]
        [Required]
        public DateTime DateFeedback { get; set; }
    }
}
