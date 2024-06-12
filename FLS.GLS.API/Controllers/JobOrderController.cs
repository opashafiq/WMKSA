using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.JobOrder.Commands;
using Application.Operations.JobOrder.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;
using Application.Common.Dtos;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrderController : ControllerBase
    {
        private readonly ISender _sender;

        public JobOrderController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            //var jobOrder = await _sender.Send(new GetJobOrderById(id));
            //return jobOrder== null ? NotFound() : Ok(jobOrder);
            return Ok(await _sender.Send(new GetJobOrderById(id)));
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var jobOrders = await _sender.Send(new GetAllJobOrder());
            return Ok(jobOrders);
        }


        //Task<ICollection<JobOrder>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateJobOrder jobOrder)
        {
            try
            {
                var _jobOrder = await _sender.Send(jobOrder);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _jobOrder.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _jobOrder.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateJobOrder jobOrder)
        {
            try
            {
                var _jobOrder = await _sender.Send(jobOrder);
                //return Ok(_jobOrder);
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
        public async Task<ActionResult> Delete([FromBody] DeleteJobOrder jobOrder)
        {

            try
            {
                var _jobOrder = await _sender.Send(jobOrder);
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
