using Bank.Application.Commands.BankOperationCommands;
using Bank.Application.Queries.BankOperationQueries;
using Bank.Application.Responses;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.API.Controllers
{
    [Route("api/v1/[controller]")]
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
        [Authorize(Roles = "Пользователь")]
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

        [HttpPost]
        [Route("make-transfer")]
        [Authorize(Roles = "Пользователь")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BankOperationResponse>> MakeTransfer([FromBody] MakeTransferCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return new JsonResult(result.Message);
        }

        [HttpPost]
        [Route("make-transfer-myaccount")]
        [Authorize(Roles = "Пользователь")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BankOperationResponse>> MakeTransferToMyAccount([FromBody] MakeTransferToMyAccountCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return new JsonResult(result.Message);
        }

        [HttpGet]
        [Route("get-bank-operations/{userId}")]
        [Authorize(Roles = "Пользователь")]
        public async Task<List<BankOperation>> GetBankOperationsByUserId(int userId)
        {
            // May get null retult if no bank operations for this user
            return await _mediator.Send(new GetBankOperationsByUserIdQuery(userId)); 
        }

    }
}
