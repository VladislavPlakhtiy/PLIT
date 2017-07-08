//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entityes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Photo = new HashSet<Photo>();
        }
    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecOffer { get; set; }
        public decimal Price { get; set; }
        public System.DateTime DateCreate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> Existence { get; set; }
        public Nullable<int> OrdersProductId { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photo { get; set; }
        public virtual Orders Orders { get; set; }
    }
}