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
    public class BlockAccountHandler : IRequestHandler<BlockAccountCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        public BlockAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<string> Handle(BlockAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = await _accountRepository.GetByIdAsync(request.AccountId);
            account.IsActive = false;
            account.IsBlocked = true;
            await _accountRepository.UpdateAsync(account);
            return $"{account.AccountType} пользователя {account.OwnerName} был заблокирован!";
        }
    }
}
