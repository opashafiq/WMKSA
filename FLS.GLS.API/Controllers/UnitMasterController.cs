using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.UnitMaster.Commands;
using Application.Operations.UnitMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Application.Operations.RecItemMaster.Queries;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public UnitMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var unitMaster = await _sender.Send(new GetUnitMasterById(id));
            return Ok(unitMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var unitMasters = await _sender.Send(new GetAllUnitMaster());
            return Ok(unitMasters);
        }

        [HttpGet("getkeyvaluepair")]
        public async Task<ActionResult> GetKeyValuePair()
        {
            var unitMasterKeyValuePair = await _sender.Send(new GetUnitMasterKeyValuePair());
            return Ok(unitMasterKeyValuePair);
        }


        //Task<ICollection<UnitMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateUnitMaster unitMaster)
        {
            try
            {
                var _unitMaster = await _sender.Send(unitMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _unitMaster.Id });


                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _unitMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateUnitMaster unitMaster)
        {
            try
            {
                var _unitMaster = await _sender.Send(unitMaster);
                //return Ok(_unitMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteUnitMaster unitMaster)
        {

            try
            {
                var _unitMaster = await _sender.Send(unitMaster);
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
