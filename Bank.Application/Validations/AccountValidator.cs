using Bank.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Validations
{
    public class AccountValidator : IAccountValidator
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        public AccountValidator(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }
        public bool ValidateAccountNumber(string accountNumber)
        {
            if(_accountRepository.FindAccountByAccountNumber(accountNumber) is null)
            {
                return true;
            }
            return false;
        }

        public bool ValidateIIN(string IIN)
        {
            if(_userRepository.FindUserByIIN(IIN) is null)
            {
                return true;
            }
            return false;
        }
    }
}
