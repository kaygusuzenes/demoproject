using Core.Entities;

namespace Entity.Concrete
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
