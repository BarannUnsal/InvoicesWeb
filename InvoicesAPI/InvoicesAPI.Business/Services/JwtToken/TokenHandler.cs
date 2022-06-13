using InvoicesAPI.Business.Abstraction.JwtToken;
using InvoicesAPI.Business.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Services.JwtToken
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int minute)
        {
            Token token = new();
            // Security Key oluşturulması
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            // Şifrelenmiş Kimlik
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            // Ayarlar
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
