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
    public class UnBlockAccountHandler : IRequestHandler<UnBlockAccountCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserServices _userServices;
        public UnBlockAccountHandler(IAccountRepository accountRepository, IUserServices userServices)
        {
            _accountRepository = accountRepository;
            _userServices = userServices;
        }
        public async Task<string> Handle(UnBlockAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = await _accountRepository.GetByIdAsync(request.AccountId);
            account.IsActive = true;
            account.IsBlocked = false;
            string message = await _userServices.Notify(account.OwnerIIN, $"Ваш {account.AccountType} был разблокирован!");
            await _accountRepository.UpdateAsync(account);
            return $"{account.AccountType} пользователя {account.OwnerName} был разблокирован!";
        }
    }
}
