using Bank.Core.Entities;
using Bank.Core.Repositories;
using Bank.Infrastructure.Data;
using Bank.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Account FindAccountByAccountNumber(string accountNumber)
        {
            var account =  _context.Accounts.FirstOrDefault(e => e.AccountNumber == accountNumber);
            return account;
        }

        public Account FindAccountByOwnerIIN(string IIN)
        {
            var account =  _context.Accounts.FirstOrDefault(e => e.OwnerIIN == IIN);
            return account;
        }
    }
}
