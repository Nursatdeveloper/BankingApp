﻿using Bank.Application.Commands.BankOperationCommands;
using Bank.Application.Mappers;
using Bank.Application.Responses;
using Bank.Application.Validations;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.BankOperationHandlers.BankOperationCommandHandlers
{
    public class MakeDepositHandler : IRequestHandler<MakeDepositCommand, BankOperationResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountValidator _accountValidator;

        public MakeDepositHandler(IUserRepository userRepository, IAccountRepository accountRepository, IAccountValidator accountValidator)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _accountValidator = accountValidator;

        }
        public async Task<BankOperationResponse> Handle(MakeDepositCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.UserId);

            Account account = user.Accounts.FirstOrDefault(e => e.AccountType == request.DepositAccountType);
            if (_accountValidator.AccountIsNotActiveOrBlocked(account))
            {
                BankOperationResponse accountIsNotAccessibleResponse = new()
                {
                    IsSuccess = false,
                    Message = "Счет недоступен для пополнения!"
                };
            }
            account.Balance += request.DepositAmount;


            BankOperation bankOperation = new()
            {
                BankOperationType = "Пополнение",
                BankOperationMaker = "Nursat Bank",
                BankOperationParticipant = account.OwnerName,
                BankOperationTime = DateTime.Now,
                BankOperationMakerId = user.UserId,
                BankOperationMoneyAmount = request.DepositAmount,
                CurrencyType = request.CurrencyType,
                ToAccount = request.DepositAccountType,
            };
            account.BankOperations.Add(bankOperation);
            await _accountRepository.UpdateAsync(account);
            BankOperationResponse successfullBankOperation = BankOperationMapper.Mapper.Map<BankOperationResponse>(bankOperation);
            successfullBankOperation.IsSuccess = true;
            successfullBankOperation.Message = "Пополнение прошло успешно!";
            return successfullBankOperation;
        }
    }
}
