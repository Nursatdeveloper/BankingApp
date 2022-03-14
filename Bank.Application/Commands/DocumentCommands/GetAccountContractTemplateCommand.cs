using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.DocumentCommands
{
    public class GetAccountContractTemplateCommand : IRequest<byte[]>
    {
    }
}
