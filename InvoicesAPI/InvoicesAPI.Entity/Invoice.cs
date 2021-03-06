using InvoicesAPI.Entity.Common;
using System.Collections.Generic;

namespace InvoicesAPI.Entity
{
    public class Invoice : BaseEntity
    {
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
        public ICollection<InvoiceImageFile> InvoiceImageFiles { get; set; }
    }
}
