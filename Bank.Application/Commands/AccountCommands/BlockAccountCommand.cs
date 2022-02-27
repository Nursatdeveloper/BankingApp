using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.AccountCommands
{
    public class BlockAccountCommand : IRequest<string>
    {
        public int AccountId { get; set; }
    }
}
