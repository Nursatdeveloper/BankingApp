﻿using Bank.Application.Commands.AccountCommands;
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
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountServices _accountServices;
        public CreateAccountHandler(IUserRepository userRepository, IAccountServices accountServices)
        {
            _userRepository = userRepository;
            _accountServices = accountServices;
        }
        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.UserId);
            Account createdAccount = _accountServices.CreateAccountFor(user, request.AccountType);
            user.Accounts.Add(createdAccount);
            try
            {
                await _userRepository.UpdateAsync(user);
                return "Account was created";
            }
            catch
            {
                return "Account was not created!";
            }  
        }
    }
}
