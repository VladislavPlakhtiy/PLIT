using System.Data.Entity;
using Domain.Entityes;

namespace Domain.Concrete
{

    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }
    }

    public class ShopContext : Context
    {
        public virtual DbSet<Product> Product { get; set; }
        //public virtual DbSet<Category> Category { get; set; }
        // public virtual DbSet<Status> Status { get; set; }
        // public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        // public virtual DbSet<Delivery> Delivery { get; set; }
    }

}
