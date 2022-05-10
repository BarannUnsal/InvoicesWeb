using InvoicesAPI.Api.Models.Invoice;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.RequestParameters;
using InvoicesAPI.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InvoiceController(IInvoicesReadRepository readRepository, IInvociesWriteRepository writeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _webHostEnvironment = webHostEnvironment;
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
                IsActive = model.isActive
            });
            await _writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(VM_Invoice_Update model)
        {
            Invoice invoice = await _readRepository.GetByIdAsync(model.Id);
            invoice.IsActive = model.isActive;
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
            //wwwroot/resource/invoices-images
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/invoices-images");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            
            Random r = new();

            foreach(IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }
    }
}
