using InvoicesAPI.Api.Models.User;
using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.UserRepo;
using InvoicesAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InvoicesAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IUserReadRepository _userRead;
        private readonly IUserWriteRepository _userWrite;

        public UserController(IUserReadRepository userRead, IUserWriteRepository userWrite)
        {
            _userRead = userRead;
            _userWrite = userWrite;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(_userRead.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(string id)
        {
            return Ok(await _userRead.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(VM_User_Create model)
        {
            await _userWrite.AddAsync(new()
            {
                Name = model.Name,
                Surname = model.Surname,
                TcNo = model.TcNo,
                isHaveCar = model.isHaveCar,
                CarPlate = model.CarPlate,
                Email = model.Email
            });
            await _userWrite.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(VM_User_Update model)
        {
            User user = await _userRead.GetByIdAsync(model.Id);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.TcNo = model.TcNo;
            user.Email = model.Email;
            user.isHaveCar = model.isHaveCar;
            user.CarPlate = model.CarPlate;
            await _userWrite.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userWrite.RemoveAsync(id);
            await _userWrite.SaveAsync();
            return Ok();
        }
    }
}
