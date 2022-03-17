using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class OrderAddDto
    {

        public int ProductId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerAddressId { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalCost
        {
            get
            {
                decimal total = ItemPrice * Quantity;
                total = total - ((total * Discount) / 100);
                total = total + ((total * Tax) / 100);
                return total;
            }
        }
        public string Status { get; set; }

    }
}
