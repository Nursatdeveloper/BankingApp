using Bank.Application.Commands.UserCommands;
using Bank.Application.Queries.UserQueries;
using Bank.Application.Responses;
using Bank.Core.Entities;
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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("/delete/{id}")]
        public async Task<JsonResult> DeleteUser(int id)
        {
            bool success = await _mediator.Send(new DeleteUserCommand(id));
            if(success)
            {
                return new JsonResult("Deleted successfull!");
            }
            return new JsonResult("Delete failed!");
        }
    }
}
