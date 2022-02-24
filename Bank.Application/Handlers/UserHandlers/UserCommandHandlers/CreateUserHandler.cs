using Bank.Application.Commands.UserCommands;
using Bank.Application.Mappers;
using Bank.Application.Responses;
using Bank.Application.Services;
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
        public CreateUserHandler(IUserRepository userRepository, IUserServices userServices)
        {
            _userRepository = userRepository;
            _userServices = userServices;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User userEntity = UserMapper.Mapper.Map<User>(request);
            if(userEntity is null)
            {
                throw new ApplicationException("Issue with mapper UserMapper");
            }
            userEntity.CardNumber = await _userServices.GenerateCardNumber();
            User newUser = await _userRepository.AddAsync(userEntity);
            UserResponse userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }
    }
}
