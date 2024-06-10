using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.Person.Commands;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ISender _sender;

        public PersonController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var person = await _sender.Send(new GetPersonById(id));
            return Ok(person);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreatePerson person)
        {
            var _person = await _sender.Send(person);
            return Ok(_person);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdatePerson person)
        {
            var _person = await _sender.Send(person);
            return Ok(_person);
        }        
        
        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeletePerson person)
        {
            var _person = await _sender.Send(person);
            return Ok(_person);
        }
    }
}
