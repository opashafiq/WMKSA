using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Operations.Person.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Application.Operations.DriverMaster.Commands;
using Application.Operations.DriverMaster.Queries;
using FLS.GLS.API.Classes;
using System.Xml;
using FLS.GLS.API.Models;
using Azure.Core;
using Domain.Entities;
using Application.Abstractions;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DriverMasterController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IErrorHandlingService _errorHandlingService;

        public DriverMasterController(ISender sender, IErrorHandlingService errorHandlingService)
        {
            _sender = sender;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var driverMaster = await _sender.Send(new GetDriverMasterById(id));
            return Ok(driverMaster);
        }        
        
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var driverMasters = await _sender.Send(new GetAllDriverMaster());
            return Ok(driverMasters);
        }          
        
        [HttpGet("getallwithimage")]
        public async Task<ActionResult> GetAllWithImage()
        {
            var driverMasters = await _sender.Send(new GetAllDriverMasterWithImage());
            return Ok(driverMasters);
        }        
        
        [HttpGet("getkeyvaluepair")]
        public async Task<ActionResult> GetKeyValuePair()
        {
            var driverMasters = await _sender.Send(new GetDriverMasterKeyValuePair());
            return Ok(driverMasters);
        }


        //Task<ICollection<DriverMaster>>

        [HttpPost("create")]
        [RequestSizeLimit(10_000_000)] // Limit file size to 10MB
        public async Task<ActionResult> Create([FromForm] CreateDriverMasterRequest request)
        {
            try
            {
                // Convert the uploaded file to a byte array
                byte[] imageData;
                if (request.ImageBase64 == null)
                {
                    imageData = null;
                }
                else
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.ImageBase64.CopyToAsync(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                }

                // Create the command and handle it
                var command = new CreateDriverMaster
                {
                    DriverCode = request.DriverCode,
                    DriverName = request.DriverName,
                    Company = request.Company,
                    DrivingLiscencNo = request.DrivingLiscencNo,
                    ExpiryDate = request.ExpiryDate,
                    IdCopy = request.IdCopy,
                    MobileNo = request.MobileNo,
                    TelNo = request.TelNo,
                    EntryBy = request.EntryBy,
                    EntryDate = request.EntryDate,
                    DriverNo = request.DriverNo,
                    TransporterMasterId = request.TransporterMasterId,
                    ImageBase64 = imageData
                };
                
                var _driverMaster = await _sender.Send(command);


                // Create a URI for the newly created resource
                var createdResourceUri = Url.Action(nameof(GetById), new { id = _driverMaster.Id });

                // Create custom response object
                var response = new CreateResponseLong
                {
                    Id = _driverMaster.Id,
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
        public async Task<ActionResult> Update([FromForm] UpdateDriverMasterRequest request)
        {
            try
            {
                // Convert the uploaded file to a byte array
                byte[] imageData = null;
                // Check if the image file is provided and not null
                if (request.ImageBase64 != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.ImageBase64.CopyToAsync(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                }
                // Create the command and handle it
                var command = new UpdateDriverMaster
                {
                    Id = request.Id,
                    DriverCode = request.DriverCode,
                    DriverName = request.DriverName,
                    Company = request.Company,
                    DrivingLiscencNo = request.DrivingLiscencNo,
                    ExpiryDate = request.ExpiryDate,
                    IdCopy = request.IdCopy,
                    MobileNo = request.MobileNo,
                    TelNo = request.TelNo,
                    EntryBy = request.EntryBy,
                    EntryDate = request.EntryDate,
                    DriverNo = request.DriverNo,
                    TransporterMasterId = request.TransporterMasterId,
                    ImageBase64 = imageData
                };
                var _driverMaster = await _sender.Send(command);

                //return Ok(_driverMaster);
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
        public async Task<ActionResult> Delete([FromBody] DeleteDriverMaster driverMaster)
        {

            try
            {
                var _driverMaster = await _sender.Send(driverMaster);
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
