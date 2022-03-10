using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.UserQueries
{
    public class GetNotificationsByUserIdQuery : IRequest<List<Notification>>
    {
        public int UserId { get; set; }
        public GetNotificationsByUserIdQuery(int id)
        {
            UserId = id;
        }
    }
}
