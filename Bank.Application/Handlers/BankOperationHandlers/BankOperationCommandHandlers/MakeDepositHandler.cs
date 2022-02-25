using Bank.Application.Commands.BankOperationCommands;
using Bank.Application.Mappers;
using Bank.Application.Responses;
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
        public MakeDepositHandler(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }
        public async Task<BankOperationResponse> Handle(MakeDepositCommand request, CancellationToken cancellationToken)
        {
            User userByPhoneNumber = _userRepository.FindUserByPhoneNumber(request.DepositMakerTelephone);
            User userByCardNumber = _userRepository.FindUserByCardNumber(request.DepositMakerCardNumber);
            if(userByPhoneNumber is null && userByCardNumber is null)
            {
                BankOperationResponse userNotFoundResponse = new()
                {
                    IsSuccess = false,
                    Message = "Пользователь не найден!"
                };
                return userNotFoundResponse;
            }
            User user = userByPhoneNumber;
            if(user is null) { user = userByCardNumber; }

            Account account = user.Accounts.FirstOrDefault(e => e.AccountType == request.DepositAccountType);
            if (account.IsActive == false || account.IsBlocked == true)
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
                BankOperationMaker = account.OwnerName,
                BankOperationParticipant = "None",
                BankOperationTime = DateTime.Now,
                BankOperationMakerId = user.UserId,
                BankOperationMoneyAmount = request.DepositAmount
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
