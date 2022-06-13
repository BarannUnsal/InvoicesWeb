using InvoicesAPI.Business.Abstraction.JwtToken;
using InvoicesAPI.Business.DTOs;
using InvoicesAPI.Business.Exceptions.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<InvoicesAPI.Entity.Identity.AppUser> _userManager;
        readonly SignInManager<InvoicesAPI.Entity.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(
            Microsoft.AspNetCore.Identity.UserManager<InvoicesAPI.Entity.Identity.AppUser> userManager, 
            SignInManager<Entity.Identity.AppUser> signInManager, 
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Entity.Identity.AppUser user = await _userManager.FindByNameAsync(request.SurnameOrMail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.SurnameOrMail);
            }

            if (user == null)
                throw new NotFoundUserException("Kullanıcı veya şifre hatalı...");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserCommandSuccessRespone()
                {
                    Token = token
                };
            }

            return new LoginUserCommandErrorResponse()
            {
                Message = "Giriş başarılı değil. Lütfen kullanıcı adını veya şifreyi kontrol ediniz!"
            };
        }
    }
}
