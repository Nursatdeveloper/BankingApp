using Bank.Application.Commands.UserCommands;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserCommandHandlers
{
    public class ChangeUserNotificationStatusHandler : IRequestHandler<ChangeUserNotificationStatusCommand, bool>
    {
        private readonly INotificationRepository _notificationRepository;
        public ChangeUserNotificationStatusHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task<bool> Handle(ChangeUserNotificationStatusCommand request, CancellationToken cancellationToken)
        {
            while (true)
            {
                var notification = await _notificationRepository.GetNotificationByUserId(request.UserId);
                if (notification == null)
                {
                    break;
                }
                notification.IsSeen = true;
                await _notificationRepository.UpdateAsync(notification);
            }
            return true;
        }
    }
}
