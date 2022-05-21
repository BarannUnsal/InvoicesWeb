using InvoicesAPI.Api.Models.House;
using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly IHouseReadRepository _readRepository;
        private readonly IHouseWriteRepository _writeRepository;
        public HousesController(IHouseReadRepository readRepository, IHouseWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHouse()
        {
            return Ok(_readRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdHouse(string id)
        {
            return Ok(await _readRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouse(VM_House_Create model)
        {
            await _writeRepository.AddAsync(new()
            {
                AptNo = model.AptNo,
                Block = model.Block,
                Type = model.Type,
                isEmpty = model.isEmpty
            });
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHouse(VM_House_Update model)
        {
            House house = await _readRepository.GetByIdAsync(model.Id);
            house.Type = model.Type;
            house.Block = model.Block;
            house.AptNo = model.AptNo;
            house.isEmpty = model.isEmpty;
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHouse(string id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();
        }
    }
}
