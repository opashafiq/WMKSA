using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.RecItemMaster.Commands;
using Application.Operations.RecItemMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Application.Operations.ItemsRateMaster.Queries;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RecItemMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public RecItemMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var recItemMaster = await _sender.Send(new GetRecItemMasterById(id));
            return Ok(recItemMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var recItemMasters = await _sender.Send(new GetAllRecItemMaster());
            return Ok(recItemMasters);
        }

        [HttpGet("getkeyvaluepair")]
        public async Task<ActionResult> GetKeyValuePair()
        {
            var irecItemMasterKeyValuePair = await _sender.Send(new GetRecItemMasterKeyValuePair());
            return Ok(irecItemMasterKeyValuePair);
        }

        //Task<ICollection<RecItemMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateRecItemMaster recItemMaster)
        {
            try
            {
                var _recItemMaster = await _sender.Send(recItemMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _recItemMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _recItemMaster.Id,
                    Message = "Created Successfully"
                };

                // Return a 201 Created response with the custom message and the URI
                return Created(createdResourceUri, response);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdateRecItemMaster recItemMaster)
        {
            try
            {
                var _recItemMaster = await _sender.Send(recItemMaster);
                //return Ok(_recItemMaster);
                // Create custom response object
                var response = new CustomResponse
                {
                    Message = "Updated Successfully"
                };

                return Ok(response);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteRecItemMaster recItemMaster)
        {

            try
            {
                var _recItemMaster = await _sender.Send(recItemMaster);
                // Create custom response object
                var response = new CustomResponse
                {
                    Message = "Deleted Successfully"
                };
                return Ok(response);
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
