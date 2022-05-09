using InvoicesAPI.Entity.Common;
using System;

namespace InvoicesAPI.Entity
{
    public class Invoice : BaseEntity
    {
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
        public bool IsActive { get; set; }
    }
}
