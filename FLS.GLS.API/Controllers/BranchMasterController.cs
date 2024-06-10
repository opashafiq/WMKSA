using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.BranchMaster.Commands;
using Application.Operations.BranchMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public BranchMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var branchMaster = await _sender.Send(new GetBranchMasterById(id));
            return Ok(branchMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var branchMasters = await _sender.Send(new GetAllBranchMaster());
            return Ok(branchMasters);
        }


        //Task<ICollection<BranchMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateBranchMaster branchMaster)
        {
            try
            {
                var _branchMaster = await _sender.Send(branchMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _branchMaster.Id });

                // Create custom response object
                var response = new CreateResponseInt
                {
                    Id = _branchMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateBranchMaster branchMaster)
        {
            try
            {
                var _branchMaster = await _sender.Send(branchMaster);
                //return Ok(_branchMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteBranchMaster branchMaster)
        {

            try
            {
                var _branchMaster = await _sender.Send(branchMaster);
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
