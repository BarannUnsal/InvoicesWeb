using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.InvoiceImageFile.GetInvoiceImage
{
    public class GetInvoiceImageQueryHandler : IRequestHandler<GetInvoiceImageQueryRequest, List<GetInvoiceImageQueryResponse>>
    {
        readonly IInvoicesReadRepository _invoiceReadRepository;
        readonly IConfiguration _configuration;
        public GetInvoiceImageQueryHandler(IInvoicesReadRepository invoiceReadRepository, IConfiguration configuration)
        {
            _invoiceReadRepository = invoiceReadRepository;
            _configuration = configuration;
        }
        public async Task<List<GetInvoiceImageQueryResponse>> Handle(GetInvoiceImageQueryRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.Invoice? invoice = await _invoiceReadRepository.Table.Include(p => p.InvoiceImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id)); ;
            return invoice?.InvoiceImageFiles.Select(p => new GetInvoiceImageQueryResponse
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id,
            }).ToList();
        }
    }
}
