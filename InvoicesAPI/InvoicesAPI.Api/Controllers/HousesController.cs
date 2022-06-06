using InvoicesAPI.Business.Features.Command.House.CreateHouse;
using InvoicesAPI.Business.Features.Command.House.RemoveHouse;
using InvoicesAPI.Business.Features.Command.House.UpdateHouse;
using InvoicesAPI.Business.Features.Queries.House.GetByIdHouse;
using InvoicesAPI.Business.Features.Queries.House.GetHouse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        readonly IMediator _mediator;
        public HousesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetHouse([FromQuery] GetHouseQueryRequest request)
        {
            GetHouseQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdHouse([FromBody] GetByIdHouseQueryRequest request)
        {
            GetByIdHouseQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouse(CreateHouseCommandRequest request)
        {
            CreateHouseCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHouse([FromBody] UpdateHouseCommandRequest request)
        {
            UpdateHouseCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteHouse([FromRoute] RemoveHouseCommandRequest request)
        {
            RemoveHouseCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
