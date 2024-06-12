using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.CustomerMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;
using Application.Operations.SubCustomerMaster.Queries;
using Application.Operations.SubCustomerMaster.Commands;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SubCustomerMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public SubCustomerMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var subCustomerMaster = await _sender.Send(new GetSubCustomerMasterById(id));
            return Ok(subCustomerMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var subCustomerMasters = await _sender.Send(new GetAllSubCustomerMaster());
            return Ok(subCustomerMasters);
        }


        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateSubCustomerMaster subCustomerMaster)
        {
            try
            {
                var _subCustomerMaster = await _sender.Send(subCustomerMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _subCustomerMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _subCustomerMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateSubCustomerMaster subCustomerMaster)
        {
            try
            {
                var _subCustomerMaster = await _sender.Send(subCustomerMaster);
                //return Ok(_customerMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteSubCustomerMaster subCustomerMaster)
        {

            try
            {
                var _subCustomerMaster = await _sender.Send(subCustomerMaster);
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
