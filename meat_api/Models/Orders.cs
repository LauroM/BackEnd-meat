using System.ComponentModel.DataAnnotations.Schema;

namespace meat_api.Models
{
    [Table("Orders")]
    public class Orders
    {
        public int Id { get; set; }
        public string MenuId { get; set; }
        public string Address { get; set; }
        public string OptionalAddress { get; set; }
        public string Number { get; set; }
        public string paymentOption { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public double Quantity { get; set; }
    }
}