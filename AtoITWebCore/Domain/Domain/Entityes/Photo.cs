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
    
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public bool? Priority { get; set; }
        public string PhotoUrl { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
