using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class Photo
    {
        [Key]
        [Display(Name = "PhotoId")]
        public int PhotoId { get; set; }

        [Display(Name = "Приоритет фото")]
        [Required]
        public bool? Priority { get; set; }

        [Display(Name = "URL фото")]
        [Required]
        public string PhotoUrl { get; set; }

        public virtual Product Product { get; set; }
    }
}
