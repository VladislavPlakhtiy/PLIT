using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    /// <summary>
    /// заказ - сейчас не используется, возможно будет использован в качестве шаблона формы отправки письма.
    /// </summary>
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
        public string Delivery { get; set; }
        public string Comments { get; set; }
        public DateTime DateOrder { get; set; }
        public ICollection<Product> Product { get; set; }
      
    }
}
