using Bank.Application.Queries.UserQueries;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserQueryHandlers
{
    public class GetGeneralInfoAboutUserHandler : IRequestHandler<GetGeneralInfoAboutUserQuery, List<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IBankOperationRepository _bankOperationRepository;
        public GetGeneralInfoAboutUserHandler(IUserRepository userRepository, IAccountRepository accountRepository, IBankOperationRepository bankOperationRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _bankOperationRepository = bankOperationRepository;
        }
        public async Task<List<int>> Handle(GetGeneralInfoAboutUserQuery request, CancellationToken cancellationToken)
        {
            List<int> data = new();

            var users = await _userRepository.GetAllAsync();
            int userNumber = users.Count();
            data.Add(userNumber);
            int male = 0;
            int female = 0;

            foreach(var user in users)
            {
                if(user.Gender == "Мужской")
                {
                    male++;
                }
                else
                {
                    female++;
                }
            }

   
            var accounts = await _accountRepository.GetAllAsync();
            int accountNumber = accounts.Count();
            int currentAccount = 0;
            int deposit = 0;
            int moneyInBank = 0;
            foreach(var account in accounts)
            {
                if(account.AccountType == "Текущий счет")
                {
                    currentAccount++;
                }
                else
                {
                    deposit++;
                }
                moneyInBank += account.Balance;
            }
            data.Add(accountNumber);
            data.Add(currentAccount);
            data.Add(deposit);

            var bankOperations = await _bankOperationRepository.GetAllAsync();
            int bankOperationNumber = bankOperations.Count();
            data.Add(bankOperationNumber);
            data.Add(moneyInBank);

            data.Add(male);
            data.Add(female);

            return data;

        }
    }
}
