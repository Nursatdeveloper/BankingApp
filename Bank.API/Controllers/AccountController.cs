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
        [Route("create-account")]
        [Authorize(Roles = "Пользователь")]
        public async Task<JsonResult> CreateBankAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("activate-account")]
        [Authorize(Roles = "Пользователь")]
        public async Task<JsonResult> ActivateBankAccount([FromBody] ActivateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("deactivate-account")]
        [Authorize(Roles = "Пользователь")]
        public async Task<JsonResult> DeactivateBankAccount([FromBody] DeactivateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("block-account")]
        [Authorize(Roles = "Администратор")]
        public async Task<JsonResult> BlockBankAccount([FromBody] BlockAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("unblock-account")]
        [Authorize(Roles = "Администратор")]
        public async Task<JsonResult> UnblockBankAccount([FromBody] UnBlockAccountCommand command)
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

        [HttpGet]
        [Route("get-all-accounts")]
        [Authorize(Roles = "Администратор")]
        public async Task<IReadOnlyList<Account>> GetAllAccounts()
        {
            var accounts = await _mediator.Send(new GetAllAccountsQuery());
            return accounts;
        }
    }
}
