using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.UserCommands
{
    public class SendNotificationToUserCommand : IRequest<bool>
    {
        public string NotificationText { get; set; }
        public string NotificationReceiver { get; set; }
    }
}
