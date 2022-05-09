using InvoicesAPI.Api.Models.Invoice;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.RequestParameters;
using InvoicesAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoicesReadRepository _readRepository;
        private readonly IInvociesWriteRepository _writeRepository;
        public InvoiceController(IInvoicesReadRepository readRepository, IInvociesWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoice([FromQuery] Pagination pagination)
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
                isActive = model.isActive
            });
            await _writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(VM_Invoice_Update model)
        {
            Invoice invoice = await _readRepository.GetByIdAsync(model.Id);
            invoice.isActive = model.isActive;
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
    }
}
