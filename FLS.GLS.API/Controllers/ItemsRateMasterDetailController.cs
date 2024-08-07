﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.ItemsRateMasterDetails.Commands;
using Application.Operations.ItemsRateMasterDetails.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using Domain.Entities;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsRateMasterDetailController : ControllerBase
    {
        private readonly ISender _sender;

        public ItemsRateMasterDetailController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var itemsRateMasterDetail = await _sender.Send(new GetItemsRateMasterDetailById(id));
            return Ok(itemsRateMasterDetail);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var itemsRateMasterDetails = await _sender.Send(new GetAllItemsRateMasterDetail());
            return Ok(itemsRateMasterDetails);
        }         
        
        [HttpGet("getallbycustomparam")]
        public async Task<ActionResult> GetAll(long customermasterid, long recitemmasterid, long unitmasterid)
        {
            var itemsRateMasterDetails = await _sender.Send(new GetAllItemsRateMasterDetailByCustomParam(customermasterid,recitemmasterid,unitmasterid));
            return Ok(itemsRateMasterDetails);
        }        
        
        [HttpGet("getbymasterid/{masterid}")]
        public async Task<ActionResult> GetAllByMasterId([FromRoute] long masterid)
        {
            var itemsRateMasterDetails = await _sender.Send(new GetAllItemsRateMasterDetailByMasterId(masterid));
            return Ok(itemsRateMasterDetails);
        }


        //Task<ICollection<ItemsRateMasterDetail>>

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateItemsRateMasterDetail itemsRateMasterDetail)
        {
            try
            {
                var _itemsRateMasterDetail = await _sender.Send(itemsRateMasterDetail);
                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _itemsRateMasterDetail.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _itemsRateMasterDetail.Id,
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
        public async Task<ActionResult> Update([FromBody] UpdateItemsRateMasterDetail itemsRateMasterDetail)
        {
            try
            {
                var _itemsRateMasterDetail = await _sender.Send(itemsRateMasterDetail);
                //return Ok(_itemsRateMasterDetail);
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
        public async Task<ActionResult> Delete([FromBody] DeleteItemsRateMasterDetail itemsRateMasterDetail)
        {

            try
            {
                var _itemsRateMasterDetail = await _sender.Send(itemsRateMasterDetail);
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
