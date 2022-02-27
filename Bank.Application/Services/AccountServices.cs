using Bank.Application.Validations;
using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountValidator _accountValidator;
        public AccountServices(IAccountValidator accountValidator)
        {
            _accountValidator = accountValidator;
        }
        public Account CreateAccountFor(User user, string accountType)
        {
            Account account = new();
            account.AccountNumber = GenerateAccountNumber(accountType);
            account.OwnerName = $"{user.FirstName} {user.LastName}";
            account.OwnerIIN = user.IIN;
            account.Balance = 0;
            account.CurrencyType = "KZT";
            account.ActivatedDate = DateTime.Now;
            account.IsActive = true;
            account.IsBlocked = false;
            account.AccountType = accountType;

            return account;
        }

        private string GenerateAccountNumber(string accountType)
        {
            string countryCode = "KZ75";
            string bankCode;
            if (accountType == "Текущий счет")
            {
                bankCode = "001C";
            }
            else if(accountType == "Депозит")
            {
                bankCode = "001D";
            }
            else
            {
                bankCode = "001B";
            }
            string userCode = "ZT";

            Random random = new();
            for (int i = 0; i < 10; i++)
            {
                string number = random.Next(10).ToString();
                userCode += number;
            }

            string accountNumber = countryCode + bankCode + userCode;
            bool isUnique = _accountValidator.ValidateAccountNumber(accountNumber);
            if(!isUnique)
            {
                GenerateAccountNumber(accountType);
            }
            return accountNumber;
        }
    }
}
