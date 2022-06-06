using System.Collections.Generic;

namespace InvoicesAPI.Entity
{
    public class InvoiceImageFile : File
    {
        public ICollection<Invoice> Invoices{ get; set; }
    }
}
