using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CartView
    {
        public List<int> ProductsId { get; set; } = new();
        public int CustomerId { get; set; }
    }
}
