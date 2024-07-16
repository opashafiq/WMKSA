using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ReceiveItemsNewReleaseRecepit.Commands;
using Application.Operations.ReceiveItemsNewReleaseRecepit.Queries;
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
    public class ReceiveItemsNewReleaseRecepitController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IErrorHandlingService _errorHandlingService;
        


        public ReceiveItemsNewReleaseRecepitController(ISender sender, IErrorHandlingService errorHandlingService)
        {
            _sender = sender;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var receiveItemsNewReleaseRecepit = await _sender.Send(new GetReceiveItemsNewReleaseRecepitById(id));
                return Ok(receiveItemsNewReleaseRecepit);
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
                var receiveItemsNewReleaseRecepits = await _sender.Send(new GetAllReceiveItemsNewReleaseRecepit());
                return Ok(receiveItemsNewReleaseRecepits);
            } catch (Exception ex)
            {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }


 
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateReceiveItemsNewReleaseRecepit receiveItemsNewReleaseRecepit)
        {
            try
            {
                var _receiveItemsNewReleaseRecepit = await _sender.Send(receiveItemsNewReleaseRecepit);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _receiveItemsNewReleaseRecepit.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _receiveItemsNewReleaseRecepit.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateReceiveItemsNewReleaseRecepit receiveItemsNewReleaseRecepit)
        {
            try
            {
                var _receiveItemsNewReleaseRecepit = await _sender.Send(receiveItemsNewReleaseRecepit);
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
        public async Task<ActionResult> Delete([FromBody] DeleteReceiveItemsNewReleaseRecepit receiveItemsNewReleaseRecepit)
        {

            try
            {
                var _receiveItemsNewReleaseRecepit = await _sender.Send(receiveItemsNewReleaseRecepit);
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
