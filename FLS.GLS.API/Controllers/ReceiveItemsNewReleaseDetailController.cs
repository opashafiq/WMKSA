using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ReceiveItemsNewReleaseDetail.Commands;
using Application.Operations.ReceiveItemsNewReleaseDetail.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveItemsNewReleaseDetailController : ControllerBase
    {
        private readonly ISender _sender;

        public ReceiveItemsNewReleaseDetailController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var receiveItemsNewReleaseDetail = await _sender.Send(new GetReceiveItemsNewReleaseDetailById(id));
            return Ok(receiveItemsNewReleaseDetail);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var receiveItemsNewReleaseDetails = await _sender.Send(new GetAllReceiveItemsNewReleaseDetail());
            return Ok(receiveItemsNewReleaseDetails);
        }


        //Task<ICollection<ReceiveItemsNewReleaseDetail>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateReceiveItemsNewReleaseDetail receiveItemsNewReleaseDetail)
        {
            try
            {
                var _receiveItemsNewReleaseDetail = await _sender.Send(receiveItemsNewReleaseDetail);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _receiveItemsNewReleaseDetail.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _receiveItemsNewReleaseDetail.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateReceiveItemsNewReleaseDetail receiveItemsNewReleaseDetail)
        {
            try
            {
                var _receiveItemsNewReleaseDetail = await _sender.Send(receiveItemsNewReleaseDetail);
                //return Ok(_receiveItemsNewReleaseDetail);
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
        public async Task<ActionResult> Delete([FromBody] DeleteReceiveItemsNewReleaseDetail receiveItemsNewReleaseDetail)
        {

            try
            {
                var _receiveItemsNewReleaseDetail = await _sender.Send(receiveItemsNewReleaseDetail);
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
