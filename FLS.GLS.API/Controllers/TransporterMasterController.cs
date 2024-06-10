using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.TransporterMaster.Commands;
using Application.Operations.TransporterMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Application.Operations.DriverMaster.Queries;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TransporterMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public TransporterMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var transporterMaster = await _sender.Send(new GetTransporterMasterById(id));
            return Ok(transporterMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var transporterMasters = await _sender.Send(new GetAllTransporterMaster());
            return Ok(transporterMasters);
        }

        [HttpGet("getkeyvaluepair")]
        public async Task<ActionResult> GetKeyValuePair()
        {
            var transporterMasterKeyValuePair = await _sender.Send(new GetTransporterMasterKeyValuePair());
            return Ok(transporterMasterKeyValuePair);
        }

        //Task<ICollection<TransporterMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateTransporterMaster transporterMaster)
        {
            try
            {
                var _transporterMaster = await _sender.Send(transporterMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _transporterMaster.Id });

                // Create custom response object
                var response = new CreateResponseInt
                {
                    Id = _transporterMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateTransporterMaster transporterMaster)
        {
            try
            {
                var _transporterMaster = await _sender.Send(transporterMaster);
                //return Ok(_transporterMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteTransporterMaster transporterMaster)
        {

            try
            {
                var _transporterMaster = await _sender.Send(transporterMaster);
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
