using System.Collections.Generic;

namespace InvoicesAPI.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long TcNo { get; set; }
        public string Email { get; set; }
        public bool isHaveCar { get; set; }
        public string? CarPlate{ get; set; }
        public ICollection<House> Houses { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }
    }
}
