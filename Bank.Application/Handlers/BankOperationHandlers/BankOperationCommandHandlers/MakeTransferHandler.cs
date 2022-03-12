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
    public class MakeTransferHandler : IRequestHandler<MakeTransferCommand, BankOperationResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountValidator _accountValidator; 
        public MakeTransferHandler(IUserRepository userRepository, IAccountRepository accountRepository, IAccountValidator accountValidator)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _accountValidator = accountValidator;
        }
        public async Task<BankOperationResponse> Handle(MakeTransferCommand request, CancellationToken cancellationToken)
        {
            User transferMaker = await _userRepository.GetUserById(request.TransferMakerId);
            User transferReceiver = _userRepository.FindUserByPhoneNumber(request.ReceiverTelephone);

            Account fromAccount = transferMaker.Accounts.FirstOrDefault(e => e.AccountType == request.TransferFromAccountType);
            Account toAccount = transferReceiver.Accounts.FirstOrDefault(e => e.AccountType == request.TransferToAccountType);

            if(_accountValidator.AccountIsNotActiveOrBlocked(fromAccount))
            {
                BankOperationResponse currentAccountIsNotAccessible = new()
                {
                    IsSuccess = false,
                    Message = "Ваш счет не активирован или заблокирован!"
                };
                return currentAccountIsNotAccessible;
            }
            if(_accountValidator.AccountIsNotActiveOrBlocked(toAccount))
            {
                BankOperationResponse receiverAccountIsNotAccessible = new()
                {
                    IsSuccess = false,
                    Message = "Счет получателя не активирован или заблокирован!"
                };
                return receiverAccountIsNotAccessible;
            }

            if(fromAccount.Balance < request.TransferAmount)
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

            BankOperation bankOperationForMaker = new()
            {
                BankOperationType = "Перевод",
                BankOperationMaker = fromAccount.OwnerName,
                BankOperationParticipant = toAccount.OwnerName,
                BankOperationTime = DateTime.Now,
                BankOperationMakerId = transferMaker.UserId,
                BankOperationMoneyAmount = request.TransferAmount,
                FromAccount = fromAccount.AccountType,
                ToAccount = toAccount.AccountType,
                CurrencyType = request.CurrencyType
            };
            fromAccount.BankOperations.Add(bankOperationForMaker);

            BankOperation bankOperationForReceiver = new()
            {
                BankOperationType = "Пополнение",
                BankOperationMaker = fromAccount.OwnerName,
                BankOperationParticipant = toAccount.OwnerName,
                BankOperationTime = DateTime.Now,
                BankOperationMakerId = transferReceiver.UserId,
                BankOperationMoneyAmount = request.TransferAmount,
                FromAccount = fromAccount.AccountType,
                ToAccount = toAccount.AccountType,
                CurrencyType = request.CurrencyType
            };
            toAccount.BankOperations.Add(bankOperationForReceiver);

            await _accountRepository.UpdateAsync(fromAccount);
            await _accountRepository.UpdateAsync(toAccount);

            BankOperationResponse successfulTransfer = BankOperationMapper.Mapper.Map<BankOperationResponse>(bankOperationForMaker);
            successfulTransfer.IsSuccess = true;
            successfulTransfer.Message = "Перевод выполнен!";
            return successfulTransfer;

        }
    }
}
