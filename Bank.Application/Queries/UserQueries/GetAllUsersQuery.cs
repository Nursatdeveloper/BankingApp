using Bank.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace Bank.Application.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
