using System.Data.Entity;

namespace meat_api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext")
        { }
        public virtual DbSet<Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<meat_api.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<meat_api.Models.Reviews> Reviews { get; set; }
    }
}