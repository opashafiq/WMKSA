using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.PackageMaster.Commands;
using Application.Operations.PackageMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PackageMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public PackageMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var packageMaster = await _sender.Send(new GetPackageMasterById(id));
            return Ok(packageMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var packageMasters = await _sender.Send(new GetAllPackageMaster());
            return Ok(packageMasters);
        }


        //Task<ICollection<PackageMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreatePackageMaster packageMaster)
        {
            try
            {
                var _packageMaster = await _sender.Send(packageMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _packageMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _packageMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdatePackageMaster packageMaster)
        {
            try
            {
                var _packageMaster = await _sender.Send(packageMaster);
                //return Ok(_packageMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeletePackageMaster packageMaster)
        {

            try
            {
                var _packageMaster = await _sender.Send(packageMaster);
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
