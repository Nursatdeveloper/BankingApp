using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.DocumentCommands
{
    public class CreateAccountContractCommand : IRequest<byte[]>
    {
        public int UserId { get; set; }
        public string AccountType { get; set; }
        public bool Agree { get; set; }
    }
}
