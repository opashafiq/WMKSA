using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ReceiveItemsNewReleaseInvoice.Commands;
using Application.Operations.ReceiveItemsNewReleaseInvoice.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;
using Application.Services;
using Application.Abstractions;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveItemsNewReleaseInvoiceController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IErrorHandlingService _errorHandlingService;
        


        public ReceiveItemsNewReleaseInvoiceController(ISender sender, IErrorHandlingService errorHandlingService)
        {
            _sender = sender;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var receiveItemsNewReleaseInvoice = await _sender.Send(new GetReceiveItemsNewReleaseInvoiceById(id));
                return Ok(receiveItemsNewReleaseInvoice);
            } catch (Exception ex)
            {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }          
        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var receiveItemsNewReleaseInvoices = await _sender.Send(new GetAllReceiveItemsNewReleaseInvoice());
                return Ok(receiveItemsNewReleaseInvoices);
            } catch (Exception ex)
            {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }


 
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateReceiveItemsNewReleaseInvoice receiveItemsNewReleaseInvoice)
        {
            try
            {
                var _receiveItemsNewReleaseInvoice = await _sender.Send(receiveItemsNewReleaseInvoice);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _receiveItemsNewReleaseInvoice.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _receiveItemsNewReleaseInvoice.Id,
                    Message = "Created Successfully"
                };

                // Return a 201 Created response with the custom message and the URI
                return Created(createdResourceUri, response);
            } catch (Exception ex)
            {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdateReceiveItemsNewReleaseInvoice receiveItemsNewReleaseInvoice)
        {
            try
            {
                var _receiveItemsNewReleaseInvoice = await _sender.Send(receiveItemsNewReleaseInvoice);
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
        public async Task<ActionResult> Delete([FromBody] DeleteReceiveItemsNewReleaseInvoice receiveItemsNewReleaseInvoice)
        {

            try
            {
                var _receiveItemsNewReleaseInvoice = await _sender.Send(receiveItemsNewReleaseInvoice);
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
