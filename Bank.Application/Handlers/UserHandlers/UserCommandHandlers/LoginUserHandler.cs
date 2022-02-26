using Bank.Application.Commands.UserCommands;
using Bank.Application.Mappers;
using Bank.Application.Responses;
using Bank.Application.Services;
using Bank.Application.Services.JwtService;
using Bank.Core.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserCommandHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserResponse>
    {
        private readonly IUserServices _userServices;
        public LoginUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<UserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user =  _userServices.FindUserForLogin(request);
            if(user is null)
            {
                UserResponse userNotFoundResponse = new()
                {
                    IsSuccess = false,
                    Message = "Пользователь не найден!"
                };
                return userNotFoundResponse;
            }

            if(user.Password == request.Password)
            {
                var now = DateTime.UtcNow;
                var claimsIdentity = _userServices.GenerateClaimsIdentity(user);
                var jwt = new JwtSecurityToken(
                    issuer: UserAuthenticationOptions.ISSUER,
                    audience: UserAuthenticationOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(UserAuthenticationOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(UserAuthenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                UserResponse successfulLoginResponse = UserMapper.Mapper.Map<UserResponse>(user);
                successfulLoginResponse.IsSuccess = true;
                successfulLoginResponse.Message = encodedJwt;
                return successfulLoginResponse;
            }
            UserResponse passwordIncorrectResponse = new()
            {
                IsSuccess = false,
                Message = "Неправильный пароль!"
            };
            return passwordIncorrectResponse;
        }
    }
}
