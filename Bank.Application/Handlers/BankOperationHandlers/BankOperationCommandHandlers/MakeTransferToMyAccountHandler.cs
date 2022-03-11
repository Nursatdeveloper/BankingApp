using Bank.Application.Commands.BankOperationCommands;
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
    public class MakeTransferToMyAccountHandler : IRequestHandler<MakeTransferToMyAccountCommand, BankOperationResponse>
    {
        private readonly IAccountValidator _accountValidator;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public MakeTransferToMyAccountHandler(IAccountValidator accountValidator, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _accountValidator = accountValidator;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }
        public async Task<BankOperationResponse> Handle(MakeTransferToMyAccountCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.UserId);
            foreach(var account in user.Accounts)
            {
                if(_accountValidator.AccountIsNotActiveOrBlocked(account))
                {
                    BankOperationResponse accountIsNotAccessibleResponse = new()
                    {
                        IsSuccess = false,
                        Message = $"Ваш {account.AccountType} заблокирован или деактивирован!"
                    };
                    return accountIsNotAccessibleResponse;
                }
            }

            Account fromAccount = user.Accounts.FirstOrDefault(e => e.AccountType == request.FromAccount);
            Account toAccount = user.Accounts.FirstOrDefault(e => e.AccountType == request.ToAccount);
            if(request.TransferAmount > fromAccount.Balance)
            {
                BankOperationResponse invalidTransferAmountResponse = new()
                {
                    IsSuccess = false,
                    Message = "Недостаточно средств для перевода!"
                };
                return invalidTransferAmountResponse;
            }

            fromAccount.Balance -= request.TransferAmount;
            toAccount.Balance += request.TransferAmount;

            BankOperation bankOperationToAccount = new()
            {
                BankOperationType = "Пополнение",  
                BankOperationMaker = toAccount.OwnerName,
                BankOperationParticipant = fromAccount.AccountType,
                BankOperationTime = DateTime.Now,
                BankOperationMakerId = user.UserId,
                BankOperationMoneyAmount = request.TransferAmount,
                CurrencyType = request.CurrencyType,
                FromAccount = request.FromAccount,
                ToAccount = request.ToAccount
            };
            toAccount.BankOperations.Add(bankOperationToAccount);

            BankOperation bankOperationFromAccount = new()
            {
                BankOperationType = "Перевод",
                BankOperationMaker = fromAccount.OwnerName,
                BankOperationParticipant = toAccount.AccountType,
                BankOperationTime = DateTime.Now,
                BankOperationMakerId = user.UserId,
                BankOperationMoneyAmount = request.TransferAmount,
                CurrencyType = request.CurrencyType,
                FromAccount = request.FromAccount,
                ToAccount = request.ToAccount

            };
            fromAccount.BankOperations.Add(bankOperationFromAccount);

            await _accountRepository.UpdateAsync(fromAccount);
            await _accountRepository.UpdateAsync(toAccount);

            BankOperationResponse successfulOperation = BankOperationMapper.Mapper.Map<BankOperationResponse>(bankOperationFromAccount);
            successfulOperation.IsSuccess = true;
            successfulOperation.Message = "Перевод выполнен!";
            return successfulOperation;
        }
    }
}
