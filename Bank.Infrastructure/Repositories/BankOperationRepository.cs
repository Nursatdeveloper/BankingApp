using Bank.Core.Entities;
using Bank.Core.Repositories;
using Bank.Infrastructure.Data;
using Bank.Infrastructure.Repositories.Base;
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
    }
}
