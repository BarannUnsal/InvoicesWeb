using System;

namespace InvoicesAPI.Api.Models.CreditCard
{
    public class VM_CreditCard_Update
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityNumber { get; set; }
        public long CardNo { get; set; }
        public DateTime Expiration { get; set; }
    }
}
