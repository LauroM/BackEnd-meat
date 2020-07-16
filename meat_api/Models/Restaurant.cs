using System.ComponentModel.DataAnnotations.Schema;

namespace meat_api.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DeliveryEstimate { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }
        public string Hours { get; set; }
    }
}