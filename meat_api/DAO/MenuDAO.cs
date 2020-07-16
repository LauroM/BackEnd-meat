using meat_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace meat_api.DAO
{
    public class MenuDAO
    {

        private AppDbContext db = new AppDbContext();

        public List<Menu> GetMenuByRestaurantId(string id)
        {


            //Get student name of string type
            List<Menu> menu = db.Database.SqlQuery<Menu>(
                            "Select * from Menu where RestaurantId=@id", 
                             new SqlParameter("@id", id)
                        ).ToList();
   

            return menu;
        }


    }
}