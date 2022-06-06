using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.Invoice.UpdateInvoice
{
    public class UpdateInvoiceCommandRequest : IRequest<UpdateInvoiceCommandResponse>
    {
        public string Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
        public bool isActive { get; set; }
    }
}
