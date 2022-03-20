using Bank.Application.Commands.UserCommands;
using Bank.Application.Mappers;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserCommandHandlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateEmployeeHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            User userEmployee = UserMapper.Mapper.Map<User>(request);
            var result = await _userRepository.AddAsync(userEmployee);
            if (request != null)
            {
                return true;
            }
            return false;
        }
    }
}
