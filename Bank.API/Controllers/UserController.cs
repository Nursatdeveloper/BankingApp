using Bank.Application.Commands.UserCommands;
using Bank.Application.Queries.AccountQueries;
using Bank.Application.Queries.UserQueries;
using Bank.Application.Responses;
using Bank.Application.Validations;
using Bank.Core.Entities;
using Bank.Core.Repositories;
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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserResponse>> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return new JsonResult(result.Message);
        }

        [HttpPost]
        [Route("change-user-role")]
        [Authorize(Roles = "Администратор")]
        public async Task<JsonResult> ChangeRole([FromBody] ChangeUserRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return new JsonResult(result);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Администратор")]
        public async Task<JsonResult> DeleteUser(int id)
        {
            bool success = await _mediator.Send(new DeleteUserCommand(id));
            if(success)
            {
                return new JsonResult("Deleted successfull!");
            }
            return new JsonResult("Delete failed!");
        }


        [HttpGet]
        [Route("get-all-users")]
        [Authorize(Roles = "Администратор, Сотрудник")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet]
        [Route("get-user-by-id/{id}")]
        [Authorize(Roles = "Пользователь")]
        public async Task<User> GetUserById(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        [HttpGet]
        [Route("get-notifications-by-userid/{id}")]
        [Authorize(Roles = "Пользователь")]
        public async Task<List<Notification>> GetNotificationsByUserId(int id)
        {
            return await _mediator.Send(new GetNotificationsByUserIdQuery(id));
        }

        [HttpGet]
        [Route("get-user-by-telephone/{telephone}")]
        public async Task<UserResponse> GetUserByTelephone(string telephone)
        {
            return await _mediator.Send(new GetUserByTelephoneQuery(telephone));
        }

        [HttpGet]
        [Route("get-user-photo/{id}")]
        public async Task<Photo> GetUserPhoto(int id)
        {
            return await _mediator.Send(new GetUserPhotoQuery(id));
        }

        [HttpPost]
        [Route("add-user-photo")]
        public async Task<JsonResult> AddUserPhoto([FromForm] AddUserPhotoCommand command)
        {
            var isSuccess = await _mediator.Send(command);
            if (isSuccess)
            {
                return new JsonResult("Фотография сохранена!");
            }
            return new JsonResult("Не удалось сохранить фотографию!");
        }

        [HttpPost]
        [Route("change-notification-status")]
        public async Task<JsonResult> ChangeNotificationStatus([FromBody] ChangeUserNotificationStatusCommand command)
        {
            var result = await _mediator.Send(command);
            if(result == true)
            {
                return new JsonResult("true");
            }
            return new JsonResult("false");
        }


    }
}
