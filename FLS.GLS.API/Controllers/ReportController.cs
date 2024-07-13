using Application.Abstractions;
using Application.Operations.ReceiveItemsNew.Queries;
using Application.Operations.Report.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IErrorHandlingService _errorHandlingService;

        public ReportController(ISender sender, IErrorHandlingService errorHandlingService)
        {
            _sender = sender;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet("getgateinitemdetails")]
        public async Task<ActionResult> GetGateInItemDetails(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo, int? status, int? itemId,
            string? receiptNo, string? poNumber
        )
        {
            var gateIntItemDetails = await _sender.Send(new GetAllUSPGateIntItemDetails(
                customerId, subCustomerId, dateStart, dateTo,
                status, itemId, receiptNo, poNumber
                ));
            return Ok(gateIntItemDetails);
        }        
        
        [HttpGet("getgateoutitem")]
        public async Task<ActionResult> GetGateOutItem(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo, int? status, int? itemId,
            string? receiptNo, string? poNumber,string? truckNo,string? invoiceNo
        )
        {
            var gateOuttItem = await _sender.Send(new GetAllUSPGateOutItem(
                customerId, subCustomerId, dateStart, dateTo,
                status, itemId, receiptNo, poNumber,truckNo, invoiceNo
                ));
            return Ok(gateOuttItem);
        }

        [HttpGet("getgateinreport/{receiveitemsnewid}")]
        public async Task<ActionResult> GetGateInReport(long receiveitemsnewid)
        {
            try
            {
                var gateInReport = await _sender.Send(new GetUSPGateInReport(receiveitemsnewid));
                return Ok(gateInReport);
            } catch (Exception ex)
            {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }        
        
        [HttpGet("getgateoutreport/{receiveitemsnewreleaseid}")]
        public async Task<ActionResult> GetGateOutReport(long receiveitemsnewreleaseid)
        {
            try
            {
                var gateOutReport = await _sender.Send(new GetUSPGateOutReport(receiveitemsnewreleaseid));
                return Ok(gateOutReport);
            }
            catch (Exception ex) {
                return StatusCode(500, _errorHandlingService.HandleError(ex));
            }
        }
    }
}
