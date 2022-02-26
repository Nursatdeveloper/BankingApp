using Bank.Application.Commands.AccountCommands;
using Bank.Application.Queries.AccountQueries;
using Bank.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("activate")]
        [Authorize(Roles = "Пользователь")]
        public async Task<JsonResult> ActivateBankAccount([FromBody] ActivateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("get-accounts/{id}")]
        [Authorize(Roles = "Пользователь")]
        public async Task<List<Account>> GetAccountsByUserId(int id)
        {
            var accounts = await _mediator.Send(new GetAccountsByUserIdQuery(id));
            return accounts;

        }
    }
}
