using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Login
{
    public class UserDto
    {
        public string UserName { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
