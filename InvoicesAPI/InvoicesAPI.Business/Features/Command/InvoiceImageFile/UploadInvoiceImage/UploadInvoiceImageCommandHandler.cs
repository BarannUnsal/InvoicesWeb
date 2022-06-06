using InvoicesAPI.Business.Abstraction;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoiceFileRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.InvoiceImageFile.UploadInvoiceImage
{
    public class UploadInvoiceImageCommandHandler : IRequestHandler<UploadInvoiceImageCommandRequest, UploadInvoiceImageCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        public UploadInvoiceImageCommandHandler(IStorageService storageService, IInvoiceFileWriteRepository invoiceFileWriteRepository)
        {
            _storageService = storageService;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
        }
        public async Task<UploadInvoiceImageCommandResponse> Handle(UploadInvoiceImageCommandRequest request, CancellationToken cancellationToken)
        {
            var datas = await _storageService.UploadAsync("files", request.Files);

            await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(e => new InvoicesAPI.Entity.InvoiceFile()
            {
                FileName = e.fileName,
                Path = e.pathOrContainerName,
                Storage = _storageService.StorageName,
                Price = new Random().Next()
            }).ToList());
            await _invoiceFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
