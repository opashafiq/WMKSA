using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ReceiveItemsNewDetail.Commands;
using Application.Operations.ReceiveItemsNewDetail.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveItemsNewDetailController : ControllerBase
    {
        private readonly ISender _sender;

        public ReceiveItemsNewDetailController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var receiveItemsNewDetail = await _sender.Send(new GetReceiveItemsNewDetailById(id));
            return Ok(receiveItemsNewDetail);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var receiveItemsNewDetails = await _sender.Send(new GetAllReceiveItemsNewDetail());
            return Ok(receiveItemsNewDetails);
        }


        //Task<ICollection<ReceiveItemsNewDetail>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateReceiveItemsNewDetail receiveItemsNewDetail)
        {
            try
            {
                var _receiveItemsNewDetail = await _sender.Send(receiveItemsNewDetail);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _receiveItemsNewDetail.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _receiveItemsNewDetail.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateReceiveItemsNewDetail receiveItemsNewDetail)
        {
            try
            {
                var _receiveItemsNewDetail = await _sender.Send(receiveItemsNewDetail);
                //return Ok(_receiveItemsNewDetail);
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
        public async Task<ActionResult> Delete([FromBody] DeleteReceiveItemsNewDetail receiveItemsNewDetail)
        {

            try
            {
                var _receiveItemsNewDetail = await _sender.Send(receiveItemsNewDetail);
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
