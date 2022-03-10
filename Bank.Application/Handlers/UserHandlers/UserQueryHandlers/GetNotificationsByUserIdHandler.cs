using Bank.Application.Queries.UserQueries;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserQueryHandlers
{
    public class GetNotificationsByUserIdHandler : IRequestHandler<GetNotificationsByUserIdQuery, List<Notification>>
    {
        private readonly IUserRepository _userRepository;
        public GetNotificationsByUserIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<Notification>> Handle(GetNotificationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.UserId);
            List<Notification> notifications = user.Notifications;
            return notifications;
        }
    }
}
