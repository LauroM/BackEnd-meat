using meat_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace meat_api.DAO
{
    public class ReviewDAO
    {
        private AppDbContext db = new AppDbContext();

        public List<Reviews> GetReviewsByRestaurantId(string id)
        {

            //Get student name of string type
            List<Reviews> reviews = db.Database.SqlQuery<Reviews>(
                            "Select * from Reviews where RestaurantId=@id",
                             new SqlParameter("@id", id)
                        ).ToList();

            return reviews;
        }
    }
}