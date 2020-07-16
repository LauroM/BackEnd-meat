using meat_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace meat_api.DAO
{
    public class RestaurantDAO
    {
        private AppDbContext db = new AppDbContext();
        
        public Restaurant GetRestaurantByNameId(string id)
        {

            //Get student name of string type
            Restaurant restaurant = db.Database.SqlQuery<Restaurant>(
                            "Select * from Restaurant where RestaurantId=@id",
                             new SqlParameter("@id", id)
                        ).FirstOrDefault();

            return restaurant;
        }
    }
}