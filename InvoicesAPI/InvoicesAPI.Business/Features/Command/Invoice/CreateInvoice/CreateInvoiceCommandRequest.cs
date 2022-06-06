using MediatR;

namespace InvoicesAPI.Business.Features.Command.Invoice.CreateInvoice
{
    public class CreateInvoiceCommandRequest : IRequest<CreateInvoiceCommandResponse>
    {
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
    }
}
