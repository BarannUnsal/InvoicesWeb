using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<InvoicesAPI.Entity.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<InvoicesAPI.Entity.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName
            },request.Password);

            CreateUserCommandResponse response = new() { Succeeded = true };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarılı bir şekilde oluşturuldu!";
            else
                foreach (var error in result.Errors)
                    response.Message = "Hata! Kullanıcı oluşturulurken bir hata ile karşılaşıldı!";

            return response;
        }
    }
}
