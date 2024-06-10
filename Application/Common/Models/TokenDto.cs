using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class TokenDto
    {
        public TokenDto(string token, DateTime expiresIn, string tokenType)
        {
            Token = token;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
        }

        public string Token { get; set; } = default!;

        public DateTime ExpiresIn { get; set; }

        public string TokenType { get; set; } = default!;
    }
}
