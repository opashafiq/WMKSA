using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class TokenDto
    {
        public TokenDto(string username, string email,string token, DateTime expiresIn, string tokenType)
        {
            UserName = username;
            Email = email;
            Token = token;
            ExpiresIn = expiresIn;
            TokenType = tokenType;            
        }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;

        public DateTime ExpiresIn { get; set; }

        public string TokenType { get; set; } = default!;
        
    }
}
