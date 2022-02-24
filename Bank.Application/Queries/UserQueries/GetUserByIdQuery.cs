using Bank.Core.Entities;
using MediatR;

namespace Bank.Application.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }
    }
}
