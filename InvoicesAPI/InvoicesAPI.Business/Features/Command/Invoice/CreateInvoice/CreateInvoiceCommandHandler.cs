using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.Invoice.CreateInvoice
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommandRequest, CreateInvoiceCommandResponse>
    {
        readonly IInvociesWriteRepository _invoiceWriteRepository;
        public CreateInvoiceCommandHandler(IInvociesWriteRepository invoiceWriteRepository)
        {
            _invoiceWriteRepository = invoiceWriteRepository;
        }
        public async Task<CreateInvoiceCommandResponse> Handle(CreateInvoiceCommandRequest request, CancellationToken cancellationToken)
        {
            await _invoiceWriteRepository.AddAsync(new()
            {
                InvoiceNumber = request.InvoiceNumber,
                InvoiceType = request.InvoiceType,
                Title = request.Title,
                Description = request.Description,
            });
            await _invoiceWriteRepository.SaveAsync();
            return new();
        }
    }
}
