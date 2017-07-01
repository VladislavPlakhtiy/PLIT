using System.ComponentModel.DataAnnotations;

namespace DressShopDomain.Entities
{
    /// <summary>
    /// Сущьность для таблицы с фотографиями продуктов
    /// </summary>
    public class Photo
    {
        [Display(Name = "Связывающий ключь с таблицей Product")]
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Приоритет фото")]
        [Required]
        public bool Priority { get; set; }

        [Display(Name = "URL фото")]
        [Required]
        public string PhotoUrl { get; set; }
    }
}
