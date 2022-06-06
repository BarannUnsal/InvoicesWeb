using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.Invoice.GetAllInvoice
{
    public class GetAllInvoiceQueryResponse
    {
        public int TotalCount { get; set; }
        public object Invoices { get; set; } 
    }
}
