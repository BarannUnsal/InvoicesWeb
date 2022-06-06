using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.InvoiceImageFile.RemoveInvoiceImage
{
    public class RemoveInvoiceImageCommandHandler : IRequestHandler<RemoveInvoiceImageCommandRequest, RemoveInvoiceImageCommandResponse>
    {
        readonly IInvociesWriteRepository _invoiceWriteRepository;
        readonly IInvoicesReadRepository _invoiceReadRepository;
        public RemoveInvoiceImageCommandHandler(IInvociesWriteRepository invoiceWriteRepository, IInvoicesReadRepository invoiceReadRepository)
        {
            _invoiceWriteRepository = invoiceWriteRepository;
            _invoiceReadRepository = invoiceReadRepository;
        }

        public async Task<RemoveInvoiceImageCommandResponse> Handle(RemoveInvoiceImageCommandRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.Invoice invoice = _invoiceReadRepository.Table.Include(p => p.InvoiceImageFiles).FirstOrDefault(x => x.Id == Guid.Parse(request.Id));

            InvoicesAPI.Entity.InvoiceImageFile invoiceImageFile = invoice.InvoiceImageFiles.FirstOrDefault(x => x.Id == Guid.Parse(request.ImageId));
            invoice.InvoiceImageFiles.Remove(invoiceImageFile);
            await _invoiceWriteRepository.SaveAsync();
            return new();
        }
    }
}
