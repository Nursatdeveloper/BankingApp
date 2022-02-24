using Bank.Application.Commands.UserCommands;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserCommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public DeleteUserHandler(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetUserById(request.UserId);
                for(int i = 0; i < user.Accounts.Count; i++)
                {
                    await _accountRepository.DeleteAsync(user.Accounts[i].AccountId);
                }
                await _userRepository.DeleteAsync(request.UserId);
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
