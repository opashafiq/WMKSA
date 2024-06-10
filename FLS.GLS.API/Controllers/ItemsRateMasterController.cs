using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ItemsRateMaster.Commands;
using Application.Operations.ItemsRateMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Application.Operations.TransporterMaster.Queries;

namespace FLS.GLS.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsRateMasterController : ControllerBase
    {
        private readonly ISender _sender;

        public ItemsRateMasterController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var itemsRateMaster = await _sender.Send(new GetItemsRateMasterById(id));
            return Ok(itemsRateMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var itemsRateMasters = await _sender.Send(new GetAllItemsRateMaster());
            return Ok(itemsRateMasters);
        }

        [HttpGet("getkeyvaluepair")]
        public async Task<ActionResult> GetKeyValuePair()
        {
            var itemsRateMasterKeyValuePair = await _sender.Send(new GetItemsRateMasterKeyValuePair());
            return Ok(itemsRateMasterKeyValuePair);
        }


        //Task<ICollection<ItemsRateMaster>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateItemsRateMaster itemsRateMaster)
        {
            try
            {
                var _itemsRateMaster = await _sender.Send(itemsRateMaster);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _itemsRateMaster.Id });

                // Create custom response object
                var response = new CreateResponseInt
                {
                    Id = _itemsRateMaster.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateItemsRateMaster itemsRateMaster)
        {
            try
            {
                var _itemsRateMaster = await _sender.Send(itemsRateMaster);
                //return Ok(_itemsRateMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteItemsRateMaster itemsRateMaster)
        {

            try
            {
                var _itemsRateMaster = await _sender.Send(itemsRateMaster);
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
