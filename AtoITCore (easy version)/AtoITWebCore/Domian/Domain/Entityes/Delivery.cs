
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    /// <summary>
    /// выбор доставки - сейчас не используется.
    /// </summary>
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public string NameDelivery { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
