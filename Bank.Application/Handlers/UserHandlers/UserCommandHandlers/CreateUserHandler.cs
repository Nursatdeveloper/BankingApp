﻿using Bank.Application.Commands.UserCommands;
using Bank.Application.Mappers;
using Bank.Application.Responses;
using Bank.Application.Services;
using Bank.Application.Validations;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserCommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _userServices;
        private readonly IUserValidator _userValidator;
        public CreateUserHandler(IUserRepository userRepository, IUserServices userServices, IUserValidator userValidator)
        {
            _userRepository = userRepository;
            _userServices = userServices;
            _userValidator = userValidator;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (_userValidator.ValidateIIN(request.IIN) && _userValidator.ValidatePhoneNumber(request.PhoneNumber))
            {
                User userEntity = UserMapper.Mapper.Map<User>(request);
                if (userEntity is null)
                {
                    throw new ApplicationException("Issue with mapper UserMapper");
                }
                userEntity.CardNumber = await _userServices.GenerateCardNumber();
                userEntity.Role = "Пользователь";
                User newUser = await _userRepository.AddAsync(userEntity);
                UserResponse userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
                userResponse.IsSuccess = true;
                userResponse.Message = "Пользователь успешно зарегистрирован!";
                return userResponse;
            }
            UserResponse userAlreadyExistsResponse = new()
            {
                IsSuccess = false,
                Message = "Пользователь с таким телефоном или ИИНом уже зарегистрирован в базе!"
            };
            return userAlreadyExistsResponse;
        }
    }
}
