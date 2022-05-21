using InvoicesAPI.Api.Models.Invoice;
using InvoicesAPI.Business.Abstraction;
using InvoicesAPI.DataAccess.Abstract.Repository.FileRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoiceFileRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.InvoiceFileRepo;
using InvoicesAPI.DataAccess.RequestParameters;
using InvoicesAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesReadRepository _readRepository;
        private readonly IInvociesWriteRepository _writeRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        readonly IStorageService _storageService;

        public InvoicesController(IInvoicesReadRepository readRepository, IInvociesWriteRepository writeRepository, IInvoiceFileWriteRepository invoiceFileWriteRepository, IStorageService storageService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _readRepository.GetAll(false).Count();
            var invoices = _readRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.CreatedTime,
                p.UpdatedTime,
                p.InvoiceType,
                p.InvoiceNumber
            }).ToList();

            return Ok(new
            {
                totalCount,
                invoices
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdInvoice(string id)
        {
            return Ok(await _readRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(VM_Invioce_Create model)
        {
            await _writeRepository.AddAsync(new()
            {
                InvoiceNumber = model.InvoiceNumber,
                InvoiceType = model.InvoiceType,
                Title = model.Title,
                Description = model.Description,
            });
            await _writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(VM_Invoice_Update model)
        {
            Invoice invoice = await _readRepository.GetByIdAsync(model.Id);
            invoice.InvoiceNumber = model.InvoiceNumber;
            invoice.InvoiceType = model.InvoiceType;
            invoice.Title = model.Title;
            invoice.Description = model.Description;
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(string id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas = await _storageService.UploadAsync("files", Request.Form.Files);

            await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(e => new InvoiceFile()
            {
                FileName = e.fileName,
                Path = e.pathOrContainerName,
                Storage = _storageService.StorageName,
                Price = new Random().Next()
            }).ToList());
            await _invoiceFileWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
