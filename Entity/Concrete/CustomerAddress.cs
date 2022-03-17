using Core.Entities;

namespace Entity.Concrete
{
    public class CustomerAddress : EntityBase
    {
        public string AddressId { get; set; }
        public string CustomerId { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
    }
}
