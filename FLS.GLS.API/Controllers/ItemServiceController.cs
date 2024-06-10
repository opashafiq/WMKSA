using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ItemService.Commands;
using Application.Operations.ItemService.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Application.Operations.TransporterMaster.Queries;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemServiceController : ControllerBase
    {
        private readonly ISender _sender;

        public ItemServiceController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var itemService = await _sender.Send(new GetItemServiceById(id));
            return Ok(itemService);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var itemServices = await _sender.Send(new GetAllItemService());
            return Ok(itemServices);
        }

        [HttpGet("getkeyvaluepair")]
        public async Task<ActionResult> GetKeyValuePair()
        {
            var itemServiceKeyValuePair = await _sender.Send(new GetItemServiceKeyValuePair());
            return Ok(itemServiceKeyValuePair);
        }

        //Task<ICollection<ItemService>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateItemService itemService)
        {
            try
            {
                var _itemService = await _sender.Send(itemService);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _itemService.Id });

                // Create custom response object
                var response = new CreateResponseInt
                {
                    Id = _itemService.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateItemService itemService)
        {
            try
            {
                var _itemService = await _sender.Send(itemService);
                //return Ok(_itemService);
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
        public async Task<ActionResult> Delete([FromBody] DeleteItemService itemService)
        {

            try
            {
                var _itemService = await _sender.Send(itemService);
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
