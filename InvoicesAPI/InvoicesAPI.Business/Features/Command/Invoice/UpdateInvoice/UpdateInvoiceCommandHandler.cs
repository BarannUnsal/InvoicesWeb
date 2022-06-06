using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.Invoice.UpdateInvoice
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommandRequest, UpdateInvoiceCommandResponse>
    {
        readonly IInvoicesReadRepository _invoiceReadRepository;
        readonly IInvociesWriteRepository _invoiceWriteRepository;
        public UpdateInvoiceCommandHandler(IInvoicesReadRepository invoiceReadRepository, IInvociesWriteRepository invoiceWriteRepository)
        {
            _invoiceReadRepository = invoiceReadRepository;
            _invoiceWriteRepository = invoiceWriteRepository;
        }
        public async Task<UpdateInvoiceCommandResponse> Handle(UpdateInvoiceCommandRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.Invoice invoice = await _invoiceReadRepository.GetByIdAsync(request.Id);
            invoice.InvoiceNumber = request.InvoiceNumber;
            invoice.InvoiceType = request.InvoiceType;
            invoice.Title = request.Title;
            invoice.Description = request.Description;
            await _invoiceWriteRepository.SaveAsync();
            return new();
        }
    }
}
