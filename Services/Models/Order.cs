using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
    }
}
