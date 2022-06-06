using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.Invoice.GetAllInvoice
{
    public class GetAllInvoiceQueryHandler : IRequestHandler<GetAllInvoiceQueryRequest, GetAllInvoiceQueryResponse>
    {
        private readonly IInvoicesReadRepository _invoicesReadRepository;
        public GetAllInvoiceQueryHandler(IInvoicesReadRepository invoicesReadRepository)
        {
            _invoicesReadRepository = invoicesReadRepository;
        }
        public async Task<GetAllInvoiceQueryResponse> Handle(GetAllInvoiceQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _invoicesReadRepository.GetAll(false).Count();
            var invoices = _invoicesReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.CreatedTime,
                p.UpdatedTime,
                p.InvoiceType,
                p.InvoiceNumber
            }).ToList();

            return new()
            {
                Products = totalCount,
                TotalCount = totalCount
            };
        }
    }
}
