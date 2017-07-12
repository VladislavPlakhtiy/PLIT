using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
 

    public sealed class Category
    {
        
        public Category()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string NameCategory { get; set; }
       

        public ICollection<Product> Product { get; set; }
    }
}
