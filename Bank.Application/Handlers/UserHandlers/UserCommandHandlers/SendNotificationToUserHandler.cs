using Bank.Application.Commands.UserCommands;
using Bank.Application.Services;
using Bank.Core.Entities;
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
    public class SendNotificationToUserHandler : IRequestHandler<SendNotificationToUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _userService;
        public SendNotificationToUserHandler(IUserRepository userRepository, IUserServices userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        public async Task<bool> Handle(SendNotificationToUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            if (request.NotificationReceiver == "Всем")
            {
                try
                {
                    foreach (var user in users)
                    {
                        await _userService.Notify(user.IIN, request.NotificationText);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if(request.NotificationReceiver == "Клиентам")
            {
                try
                {
                    foreach (var user in users)
                    {
                        if(user.Role == "Пользователь")
                        {
                            await _userService.Notify(user.IIN, request.NotificationText);
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    foreach (var user in users)
                    {
                        if (user.Role == "Администратор" || user.Role == "Сотрудник")
                        {
                            await _userService.Notify(user.IIN, request.NotificationText);
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
