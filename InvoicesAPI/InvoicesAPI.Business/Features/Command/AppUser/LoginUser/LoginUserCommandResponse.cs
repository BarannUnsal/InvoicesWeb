using InvoicesAPI.Business.DTOs;

namespace InvoicesAPI.Business.Features.Command.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    public class LoginUserCommandSuccessRespone : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserCommandErrorResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}
