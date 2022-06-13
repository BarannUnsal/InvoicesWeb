using System;

namespace InvoicesAPI.Business.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; } 
    }
}
