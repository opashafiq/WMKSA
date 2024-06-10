using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.VendorMaster.Commands;
using Application.Operations.VendorMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public VendorMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var vendorMaster = await _sender.Send(new GetVendorMasterById(id));
            return Ok(vendorMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var vendorMasters = await _sender.Send(new GetAllVendorMaster());
            return Ok(vendorMasters);
        }


        //Task<ICollection<VendorMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateVendorMaster vendorMaster)
        {
            try
            {
                var _vendorMaster = await _sender.Send(vendorMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _vendorMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _vendorMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateVendorMaster vendorMaster)
        {
            try
            {
                var _vendorMaster = await _sender.Send(vendorMaster);
                //return Ok(_vendorMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteVendorMaster vendorMaster)
        {

            try
            {
                var _vendorMaster = await _sender.Send(vendorMaster);
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
