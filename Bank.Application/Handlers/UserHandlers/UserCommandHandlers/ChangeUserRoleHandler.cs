using Bank.Application.Commands.UserCommands;
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
    public class ChangeUserRoleHandler : IRequestHandler<ChangeUserRoleCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public ChangeUserRoleHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.UserId);
            user.Role = request.Role;
            await _userRepository.UpdateAsync(user);
            return $"Роль был изменен на: {request.Role}!";
        }
    }
}
