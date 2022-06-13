using InvoicesAPI.Business.DTOs;

namespace InvoicesAPI.Business.Abstraction.JwtToken
{
    public interface ITokenHandler 
    {
        Token CreateAccessToken(int minute);
    }
}
