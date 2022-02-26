using Bank.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<UserResponse>
    {
        public string IIN { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
    }
}
