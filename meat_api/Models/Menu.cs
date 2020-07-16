using System.ComponentModel.DataAnnotations.Schema;

namespace meat_api.Models
{
    [Table("Menu")]
    public class Menu
    {
        public int Id { get; set; }
        public string MenuId { get; set; }
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}