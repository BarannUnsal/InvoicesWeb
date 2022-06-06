using InvoicesAPI.Business.Features.Command.Invoice.CreateInvoice;
using InvoicesAPI.Business.Features.Command.Invoice.RemoveInvoice;
using InvoicesAPI.Business.Features.Command.Invoice.UpdateInvoice;
using InvoicesAPI.Business.Features.Command.InvoiceImageFile.RemoveInvoiceImage;
using InvoicesAPI.Business.Features.Command.InvoiceImageFile.UploadInvoiceImage;
using InvoicesAPI.Business.Features.Queries.Invoice.GetAllInvoice;
using InvoicesAPI.Business.Features.Queries.Invoice.GetByIdInvoice;
using InvoicesAPI.Business.Features.Queries.InvoiceImageFile.GetInvoiceImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllInvoiceQueryRequest request)
        {
            GetAllInvoiceQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdInvoice([FromBody] GetByIdInvoiceQueryRequest request)
        {
            GetByIdInvoiceQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceCommandRequest request)
        {
            CreateInvoiceCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommandRequest request)
        {
            UpdateInvoiceCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] RemoveInvoiceCommandRequest request)
        {
            RemoveInvoiceCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadInvoiceImageCommandRequest request)
        {
            UploadInvoiceImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetInvoiceImage([FromRoute] GetInvoiceImageQueryRequest request)
        {
            List<GetInvoiceImageQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("(action)/{id}")]
        public async Task<IActionResult> DeleteInvoiceImage([FromRoute] RemoveInvoiceImageCommandRequest request, string imageId)
        {
            request.ImageId = imageId;
            RemoveInvoiceImageCommandResponse response = await _mediator.Send(request);   
            return Ok(response);
        }
    }
}
