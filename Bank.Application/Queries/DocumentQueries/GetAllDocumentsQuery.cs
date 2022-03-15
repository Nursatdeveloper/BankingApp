using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.DocumentQueries
{
    public class GetAllDocumentsQuery : IRequest<List<Document>>
    {
        public int UserId { get; set; }
        public GetAllDocumentsQuery(int id)
        {
            UserId = id;
        }
    }
}
