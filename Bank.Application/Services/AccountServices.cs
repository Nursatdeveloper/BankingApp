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
        public Account ActivateAccountFor(User user, string accountType)
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

        public string GenerateAccountNumber(string accountType)
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
            return accountNumber;
        }
    }
}
