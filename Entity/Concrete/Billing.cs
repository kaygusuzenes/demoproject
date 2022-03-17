using Core.Entities;

namespace Entity.Concrete
{
    public class Billing : IEntity
    {
        public int BillingId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalCost { get; set; }
    }

}
