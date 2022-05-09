using InvoicesAPI.Api.Models.CreditCard;
using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardReadRepository _readRepository;
        private readonly ICreditCardWriteRepository _writeRepository;
        public CreditCardController(ICreditCardReadRepository readRepository, ICreditCardWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCreditCard()
        {
            return Ok(_readRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCreditCard(string id)
        {
            return Ok(await _readRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCreditCard(VM_CreditCard_Create model)
        {
            await _writeRepository.AddAsync(new()
            {
                CardNo = model.CardNo,
                Description =model.Description,
                Title = model.Title,
                SecurityNumber = model.SecurityNumber,
                Expiration = model.Expiration
            });
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCreditCard(VM_CreditCard_Update model)
        {
            CreditCard creditCard = await _readRepository.GetByIdAsync(model.Id);
            creditCard.Description = model.Description;
            creditCard.Title = model.Title;
            creditCard.CardNo = model.CardNo;
            creditCard.SecurityNumber = model.SecurityNumber;
            creditCard.Expiration = model.Expiration;
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCreditCard(string id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();
        }
    }
}
