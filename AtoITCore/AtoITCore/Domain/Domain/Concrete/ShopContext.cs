using System.Data.Entity;
using Domain.Entityes;
namespace Domain.Concrete
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }
    }
    /// <summary>
    /// Контекст для БД
    /// </summary>
    public class ShopContext : Context
    {
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
    }
}
