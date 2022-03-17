using Core.Entities;
using System;

namespace Entity.Concrete
{
    public class Product:EntityBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal ItemPrice { get; set; }
        public string Status { get; set; }
    }

}
