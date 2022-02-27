using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.AccountQueries
{
    public class GetAllAccountsQuery : IRequest<IReadOnlyList<Account>>
    {
    }
}
