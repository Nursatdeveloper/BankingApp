﻿using Bank.Application.Commands.UserCommands;
using Bank.Application.Queries.AccountQueries;
using Bank.Application.Queries.UserQueries;
using Bank.Application.Responses;
using Bank.Application.Validations;
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
        private readonly IUserValidator _userValidator;
        public UserController(IMediator mediator, IUserValidator userValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
        }

        [HttpGet]
        [Route("get-all-users")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet]
        [Route("get-user-by-id/{id}")]
        public async Task<User> GetUserById(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<JsonResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if(_userValidator.ValidateIIN(command.IIN))
            {
                var result = await _mediator.Send(command);
                return new JsonResult(result);
            }
            return new JsonResult("В базе уже существует!");

        }

        [HttpDelete]
        [Route("delete/{id}")]
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
