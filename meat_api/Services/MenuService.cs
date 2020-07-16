using meat_api.Models;
using System.Data.Entity;

namespace meat_api.Services
{
    public class MenuService
    {

        private AppDbContext db = new AppDbContext();
        public DbSet<Menu> GetAllMenu()
        {
            return db.Menus;
        }

        public Menu FindMenuByID(int id)
        {
           return db.Menus.Find(id);
        }

        public void PostMenu(Menu menu)
        {
            db.Menus.Add(menu);
            db.SaveChanges();
        }

        public void DeleteMenu(Menu menu)
        {
            db.Menus.Remove(menu);
            db.SaveChanges();
        }

    }
}