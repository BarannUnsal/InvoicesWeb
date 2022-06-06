using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.Invoice.RemoveInvoice
{
    public class RemoveInvoiceCommandHandler : IRequestHandler<RemoveInvoiceCommandRequest, RemoveInvoiceCommandResponse>
    {
        readonly IInvociesWriteRepository _invoiceWriteRepository;
        public RemoveInvoiceCommandHandler(IInvociesWriteRepository invoiceWriteRepository)
        {
            _invoiceWriteRepository = invoiceWriteRepository;
        }
        public async Task<RemoveInvoiceCommandResponse> Handle(RemoveInvoiceCommandRequest request, CancellationToken cancellationToken)
        {
            await _invoiceWriteRepository.RemoveAsync(request.Id);
            await _invoiceWriteRepository.SaveAsync();
            return new();
        }
    }
}
