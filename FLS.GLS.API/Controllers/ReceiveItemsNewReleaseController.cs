using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ReceiveItemsNewRelease.Commands;
using Application.Operations.ReceiveItemsNewRelease.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;
using Application.Operations.ReceiveItemsNew.Queries;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveItemsNewReleaseController : ControllerBase
    {
        private readonly ISender _sender;

        public ReceiveItemsNewReleaseController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var receiveItemsNewRelease = await _sender.Send(new GetReceiveItemsNewReleaseById(id));
            return Ok(receiveItemsNewRelease);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var receiveItemsNewReleases = await _sender.Send(new GetAllReceiveItemsNewRelease());
            return Ok(receiveItemsNewReleases);
        }

        [HttpGet("getgateout")]
        public async Task<ActionResult> GetGateOut(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo, int? status, int? itemId,
            string? receiptNo, string? poNumber ,string? truckNo,string? invoiceNo
        )
        {
            var receiveItemsNewReleaseGateOut = await _sender.Send(new GetAllReceiveItemsNewReleaseGateOut(
                customerId, subCustomerId, dateStart, dateTo,
                status, itemId, receiptNo, poNumber,truckNo, invoiceNo
                ));
            return Ok(receiveItemsNewReleaseGateOut);
        }

        //Task<ICollection<ReceiveItemsNewRelease>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateReceiveItemsNewRelease receiveItemsNewRelease)
        {
            try
            {
                var _receiveItemsNewRelease = await _sender.Send(receiveItemsNewRelease);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _receiveItemsNewRelease.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _receiveItemsNewRelease.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateReceiveItemsNewRelease receiveItemsNewRelease)
        {
            try
            {
                var _receiveItemsNewRelease = await _sender.Send(receiveItemsNewRelease);
                //return Ok(_receiveItemsNewRelease);
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
        public async Task<ActionResult> Delete([FromBody] DeleteReceiveItemsNewRelease receiveItemsNewRelease)
        {

            try
            {
                var _receiveItemsNewRelease = await _sender.Send(receiveItemsNewRelease);
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
