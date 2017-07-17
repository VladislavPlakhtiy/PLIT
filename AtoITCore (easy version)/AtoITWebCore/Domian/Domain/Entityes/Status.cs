using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    /// <summary>
    /// статус товара  - сейчас не используется.
    /// </summary>
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
