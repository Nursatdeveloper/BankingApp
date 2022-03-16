using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.DocumentQueries
{
    public class GetTransferInvoiceQuery : IRequest<byte[]>
    {
        public int BankOperationId { get; set; }
        public GetTransferInvoiceQuery(int id)
        {
            BankOperationId = id;
        }
    }
}
