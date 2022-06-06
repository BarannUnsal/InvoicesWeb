using MediatR;

namespace InvoicesAPI.Business.Features.Command.Invoice.RemoveInvoice
{
    public class RemoveInvoiceCommandRequest : IRequest<RemoveInvoiceCommandResponse>
    {
        public string Id { get; set; }
    }
}
