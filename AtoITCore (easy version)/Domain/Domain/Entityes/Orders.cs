using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public sealed class Orders
    {
        public Orders()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        public int OrderId { get; set; }
        public decimal Sum { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sity { get; set; }
        public string Comments { get; set; }
        public System.DateTime DateOrder { get; set; }

        
        public ICollection<Product> Product { get; set; }
        public Status Status { get; set; }
        public Delivery Delivery { get; set; }
    }
}
