using Bank.Application.Commands.AccountCommands;
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
        public UnBlockAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<string> Handle(UnBlockAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = await _accountRepository.GetByIdAsync(request.AccountId);
            account.IsActive = true;
            account.IsBlocked = false;
            await _accountRepository.UpdateAsync(account);
            return $"{account.AccountType} пользователя {account.OwnerName} был разблокирован!";
        }
    }
}
