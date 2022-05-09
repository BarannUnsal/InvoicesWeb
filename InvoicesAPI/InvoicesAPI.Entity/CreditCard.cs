using InvoicesAPI.Entity.Common;
using System;

namespace InvoicesAPI.Entity
{
    public class CreditCard : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityNumber { get; set; }
        public long CardNo { get; set; }
        public DateTime Expiration { get; set; }
    }
}

