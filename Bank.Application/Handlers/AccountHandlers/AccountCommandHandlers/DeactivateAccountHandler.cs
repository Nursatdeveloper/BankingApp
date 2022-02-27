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
    public class DeactivateAccountHandler : IRequestHandler<DeactivateAccountCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public DeactivateAccountHandler(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }
        public async Task<string> Handle(DeactivateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = _userRepository.FindUserByPhoneNumber(request.Telephone);
            if(user is null)
            {
                return "Пользователь не найден!";
            }
            if(BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                Account account = user.Accounts.FirstOrDefault(e => e.AccountType == request.AccountType);
                if(account.IsBlocked)
                {
                    return $"Ваш {account.AccountType} был заблокирован. Поэтому {account.AccountType} уже деактивирован!";
                }
                account.IsActive = false;
                await _accountRepository.UpdateAsync(account);
                return $"Ваш {account.AccountType} был деактивирован!";
            }
            return "Неправильный пароль!";
        }
    }
}
