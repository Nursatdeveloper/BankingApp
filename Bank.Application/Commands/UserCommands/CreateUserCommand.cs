using Bank.Application.Responses;
using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IIN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        //public byte[] Photo { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
