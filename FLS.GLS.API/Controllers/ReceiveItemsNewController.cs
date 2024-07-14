using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ReceiveItemsNew.Commands;
using Application.Operations.ReceiveItemsNew.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;
using Application.Operations.ReceiveItemsNewRelease.Queries;
using Application.Abstractions;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveItemsNewController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IErrorHandlingService _errorHandlingService;

        public ReceiveItemsNewController(ISender sender, IErrorHandlingService errorHandlingService)
        {
            _sender = sender;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var receiveItemsNew = await _sender.Send(new GetReceiveItemsNewById(id));
            return Ok(receiveItemsNew);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var receiveItemsNews = await _sender.Send(new GetAllReceiveItemsNew());
            return Ok(receiveItemsNews);
        }        
        
        [HttpGet("getallbyjoborderid/{joborderid}")]
        public async Task<ActionResult> GetAllByJobOrderId(long joborderid)
        {
            var receiveItemsNews = await _sender.Send(new GetAllReceiveItemsNewByJobOrderId(joborderid));
            return Ok(receiveItemsNews);
        }

        [HttpGet("getgatein")]
        public async Task<ActionResult> GetGateIn(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo, int? status, int? itemId,
            string? receiptNo, string? poNumber
        )
        {
            var receiveItemsNewFromUSPGateIn = await _sender.Send(new GetAllReceiveItemsNewFromUSPGatein(
                customerId,subCustomerId, dateStart, dateTo,    
                status, itemId, receiptNo, poNumber
                ));
            return Ok(receiveItemsNewFromUSPGateIn);
        }

        //Task<ICollection<ReceiveItemsNew>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateReceiveItemsNew receiveItemsNew)
        {
            try
            {
                var _receiveItemsNew = await _sender.Send(receiveItemsNew);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _receiveItemsNew.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _receiveItemsNew.Id,
                    Message = "Created Successfully"
                };

                // Return a 201 Created response with the custom message and the URI
                return Created(createdResourceUri, response);
            } catch (Exception ex)
            {
                return  StatusCode(500, _errorHandlingService.HandleError(ex));
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdateReceiveItemsNew receiveItemsNew)
        {
            try
            {
                var _receiveItemsNew = await _sender.Send(receiveItemsNew);
                //return Ok(_receiveItemsNew);
                // Create custom response object
                var response = new CustomResponse
                {
                    Message = "Updated Successfully"
                };

                return Ok(response);
            } catch (Exception ex) {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteReceiveItemsNew receiveItemsNew)
        {

            try
            {
                var _receiveItemsNew = await _sender.Send(receiveItemsNew);
                // Create custom response object
                var response = new CustomResponse
                {
                    Message = "Deleted Successfully"
                };
                return Ok(response);
            } catch(Exception ex)
            {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }
    }
}
