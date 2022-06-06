using InvoicesAPI.Business.Features.Command.CreditCard.CreateCreditCard;
using InvoicesAPI.Business.Features.Command.CreditCard.RemoveCreditCard;
using InvoicesAPI.Business.Features.Command.CreditCard.UpdateCreditCard;
using InvoicesAPI.Business.Features.Queries.CreditCard.GetByIdCreditCard;
using InvoicesAPI.Business.Features.Queries.CreditCard.GetCreditCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardsController : ControllerBase
    {
        readonly IMediator _mediator;
        public CreditCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCreditCard([FromQuery] GetCreditCardQueryRequest request)
        {
            GetCreditCardQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdCreditCard([FromBody] GetByIdCreditCardQueryRequest request)
        {
            GetByIdCreditCardQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCreditCard(CreateCreditCardCommandRequest request)
        {
            CreateCreditCardCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCreditCard([FromBody] UpdateCreditCardCommandRequest request)
        {
            UpdateCreditCardCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCreditCard([FromRoute] RemoveCreditCardCommandRequest request)
        {
            RemoveCreditCardCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
