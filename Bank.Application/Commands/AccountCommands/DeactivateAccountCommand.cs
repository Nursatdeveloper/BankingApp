using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.AccountCommands
{
    public class DeactivateAccountCommand : IRequest<string>
    {
        public string Telephone { get; set; }
        public string AccountType { get; set; }
        public string Password { get; set; }
    }
}
