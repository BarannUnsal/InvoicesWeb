using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.Invoice.GetAllInvoice
{
    public class GetAllInvoiceQueryRequest : IRequest<GetAllInvoiceQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
