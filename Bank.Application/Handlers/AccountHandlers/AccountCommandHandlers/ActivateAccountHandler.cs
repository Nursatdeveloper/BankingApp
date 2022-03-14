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
        private readonly IAccountRepository _accountRepository;
        private readonly IUserServices _userServices;
        public ActivateAccountHandler(IUserRepository userRepository, IAccountRepository accountRepository, IUserServices userServices)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _userServices = userServices;
        }
        public async Task<string> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.UserId);
            if(user is null)
            {
                return "Пользователь не найден!";
            }
            if(BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                Account account = user.Accounts.FirstOrDefault(e => e.AccountType == request.AccountType);
                if(account.IsBlocked)
                {
                    return $"Ваш {request.AccountType} был заблокирован! Невозможно активировать!";
                }
                account.IsActive = true;
                
                string message = await _userServices.Notify(user.IIN, $"Вы активировали {account.AccountType}!");
                await _accountRepository.UpdateAsync(account);

                return message;
            }
            return "Неправильный пароль!";
        }
    }
}
