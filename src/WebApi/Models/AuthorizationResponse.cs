using System;

namespace WebApi.Models
{
    public class AuthorizationResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
