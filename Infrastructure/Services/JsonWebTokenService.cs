using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JsonWebTokenService : IJsonWebTokenService
    {
        SignInManager<ApplicationUser> signInManager;
        UserManager<ApplicationUser> _userManager;

        public JsonWebTokenService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<TokenDto> GenerateTokenAsync(string userName, string password)
        {
            var signInResult = await signInManager.PasswordSignInAsync(userName, password, false, false);
            if (signInResult.Succeeded)
            {
                var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-signing-key this-is-signing-key this-is-signing-key"));
                var signingCredentials = new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256);
                var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, expires: DateTime.Now.AddMinutes(240));

                var user = await _userManager.FindByNameAsync(userName);

                return new TokenDto(user.UserName, user.Email,new JwtSecurityTokenHandler().WriteToken(jwt),
                jwt.ValidTo, "Bearer");
            }
            else throw new UnauthorizedAccessException();
        }
    }
}
