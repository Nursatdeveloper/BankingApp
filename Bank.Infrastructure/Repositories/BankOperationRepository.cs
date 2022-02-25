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
    public class BankOperationRepository : Repository<BankOperation>, IBankOperationRepository
    {
        public BankOperationRepository(ApplicationDbContext context) :base(context)
        {

        }

        public async Task<List<BankOperation>> GetBankOperationsByUserId(int userId)
        {
            var listOfBankOperations = await _context.BankOperations.ToListAsync();
            var bankOperations = from bankOperation in  listOfBankOperations
                                 where bankOperation.BankOperationMakerId == userId
                                 select bankOperation;
            return bankOperations.ToList();
        }
    }
}
