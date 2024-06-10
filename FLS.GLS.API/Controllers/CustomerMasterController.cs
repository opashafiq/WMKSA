using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.CustomerMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomerMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var customerMaster = await _sender.Send(new GetCustomerMasterById(id));
            return Ok(customerMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var customerMasters = await _sender.Send(new GetAllCustomerMaster());
            return Ok(customerMasters);
        }


        //Task<ICollection<CustomerMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerMaster customerMaster)
        {
            try
            {
                var _customerMaster = await _sender.Send(customerMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _customerMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _customerMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateCustomerMaster customerMaster)
        {
            try
            {
                var _customerMaster = await _sender.Send(customerMaster);
                //return Ok(_customerMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteCustomerMaster customerMaster)
        {

            try
            {
                var _customerMaster = await _sender.Send(customerMaster);
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
