using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.BankOperationQueries
{
    public class GetBankOperationsByUserIdQuery : IRequest<List<BankOperation>>
    {
        public int UserId { get; set; }
        public GetBankOperationsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
