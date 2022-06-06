
namespace InvoicesAPI.Business.Features.Queries.Invoice.GetByIdInvoice
{
    public class GetByIdInvoiceQueryResponse
    {
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
    }
}
