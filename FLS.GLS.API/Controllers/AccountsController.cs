using Application.Abstractions;
using Application.Operations.Accounting.Queries;
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
    public class AccountsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IErrorHandlingService _errorHandlingService;

        public AccountsController(ISender sender, IErrorHandlingService errorHandlingService)
        {
            _sender = sender;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet("getgateinaccounts")]
        public async Task<ActionResult> GetGateInItemDetails(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo
        )
        {
            var gateInAccounts = await _sender.Send(new GetAllUSPGateInAccounts(
                customerId, subCustomerId, dateStart, dateTo
                ));
            return Ok(gateInAccounts);
        }

    }
}
