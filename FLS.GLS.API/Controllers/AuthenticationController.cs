using Application.Authentication.Commands.Login;
using Application.Operations.Person.Commands;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FLS.GLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //private ApplicationDBContext _context;

        //UserManager<ApplicationUser> userManager;
        //SignInManager<ApplicationUser> signInManager;

        //public AuthenticationController(ApplicationDBContext context, 
        //    SignInManager<ApplicationUser> _signInManager, 
        //    UserManager<ApplicationUser> _userManager)
        //{


        //    signInManager = _signInManager;
        //    userManager = _userManager;
        //}

        private readonly ISender _sender;
        public AuthenticationController(ISender sender) => _sender = sender;

        [HttpPost("Login")]
        [AllowAnonymous]
        //public async Task<ActionResult> Login([FromBody] LoginVM model)
        //{
        //    var signInResult = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        //    if (signInResult.Succeeded)
        //    {
        //        var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-signing-key this-is-signing-key this-is-signing-key"));
        //        var signingCredentials = new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256);
        //        var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, expires: DateTime.Now.AddMinutes(30));
        //        string token = new JwtSecurityTokenHandler().WriteToken(jwt);
        //        return Ok(token);
        //    }
        //    //else if (signInResult.Succeed)
        //    return BadRequest(ModelState);
        //}        
        
        public async Task<ActionResult> Login([FromBody] LoginCommand model)
        {
            var login = await _sender.Send(model);
            return Ok(login);
        }
    }
}
