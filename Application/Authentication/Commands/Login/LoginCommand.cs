using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Login
{
    public record LoginCommand : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
    {
        private readonly IJsonWebTokenService _jsonWebTokenService;

        public LoginCommandHandler(IJsonWebTokenService jsonWebTokenService)
        {
            this._jsonWebTokenService = jsonWebTokenService;
        }
        public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            string UserName = request.UserName;
            var token = await _jsonWebTokenService.GenerateTokenAsync(request.UserName, request.Password);
            var entity = new UserDto()
            {
                UserName = UserName,
                Email=token.Email,
                Token=token.Token
            };
            return entity;
        }
    }
}
