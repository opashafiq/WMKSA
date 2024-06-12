using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.TruckMaster.Commands;
using Application.Operations.TruckMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TruckMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public TruckMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var truckMaster = await _sender.Send(new GetTruckMasterById(id));
            return Ok(truckMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var truckMasters = await _sender.Send(new GetAllTruckMaster());
            return Ok(truckMasters);
        }


        //Task<ICollection<TruckMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateTruckMaster truckMaster)
        {
            try
            {
                var _truckMaster = await _sender.Send(truckMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _truckMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _truckMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateTruckMaster truckMaster)
        {
            try
            {
                var _truckMaster = await _sender.Send(truckMaster);
                //return Ok(_truckMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteTruckMaster truckMaster)
        {

            try
            {
                var _truckMaster = await _sender.Send(truckMaster);
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
