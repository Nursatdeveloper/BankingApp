using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.DocumentCommands
{
    public class FindDocumentCommand : IRequest<Document>
    {
        public int UserId { get; set; }
        public string DocumentName { get; set; }
    }
}
