using System.ComponentModel.DataAnnotations.Schema;

namespace meat_api.Models
{
    [Table("Reviews")]
    public class Reviews
    {
        public int Id { get; set; }
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public double Rating { get; set; }
        public string Comments { get; set; }
    }
}