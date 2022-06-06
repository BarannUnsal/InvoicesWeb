using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.Invoice.GetByIdInvoice
{
    public class GetByIdInvoiceQueryHandler : IRequestHandler<GetByIdInvoiceQueryRequest, GetByIdInvoiceQueryResponse>
    {
        readonly IInvoicesReadRepository _invoicesReadRepository;
        public GetByIdInvoiceQueryHandler(IInvoicesReadRepository invoicesReadRepository)
        {
            _invoicesReadRepository = invoicesReadRepository;
        }
        public async Task<GetByIdInvoiceQueryResponse> Handle(GetByIdInvoiceQueryRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.Invoice invoice = await _invoicesReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Description = invoice.Description,
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceType = invoice.InvoiceType,
                Title = invoice.Title
            };
        }
    }
}
