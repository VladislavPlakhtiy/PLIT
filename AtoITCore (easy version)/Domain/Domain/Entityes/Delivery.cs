
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public string NameDelivery { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
