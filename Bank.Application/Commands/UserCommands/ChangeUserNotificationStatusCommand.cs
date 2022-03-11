using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.UserCommands
{
    public class ChangeUserNotificationStatusCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
