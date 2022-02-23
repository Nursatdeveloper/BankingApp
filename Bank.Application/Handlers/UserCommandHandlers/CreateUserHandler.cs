using Bank.Application.Commands.UserCommands;
using Bank.Application.Mappers;
using Bank.Application.Responses;
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
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User userEntity = UserMapper.Mapper.Map<User>(request);
            if(userEntity is null)
            {
                throw new ApplicationException("Issue with mapper UserMapper");
            }
            User newUser = await _userRepository.AddAsync(userEntity);
            UserResponse userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }
    }
}
