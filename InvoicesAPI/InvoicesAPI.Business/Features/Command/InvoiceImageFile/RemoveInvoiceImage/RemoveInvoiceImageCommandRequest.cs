using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.InvoiceImageFile.RemoveInvoiceImage
{
    public class RemoveInvoiceImageCommandRequest : IRequest<RemoveInvoiceImageCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
