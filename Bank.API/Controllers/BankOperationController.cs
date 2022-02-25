using Bank.Application.Commands.BankOperationCommands;
using Bank.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankOperationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BankOperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("make-deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BankOperationResponse>> MakeDeposit([FromBody] MakeDepositCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return new JsonResult(result.Message);
        }
    }
}
