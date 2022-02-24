using Bank.Application.Commands.AccountCommands;
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

namespace Bank.Application.Handlers.AccountHandlers.AccountCommandHandlers
{
    public class ActivateAccountHandler : IRequestHandler<ActivateAccountCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountServices _accountServices;
        public ActivateAccountHandler(IUserRepository userRepository, IAccountServices accountServices)
        {
            _userRepository = userRepository;
            _accountServices = accountServices;
        }
        public async Task<string> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.UserId);
            Account activatedAccount = _accountServices.ActivateAccountFor(user, request.AccountType);
            user.Accounts.Add(activatedAccount);
            try
            {
                await _userRepository.UpdateAsync(user);
                return "Account was activated";
            }
            catch
            {
                return "Account was not activated!";
            }  
        }
    }
}
