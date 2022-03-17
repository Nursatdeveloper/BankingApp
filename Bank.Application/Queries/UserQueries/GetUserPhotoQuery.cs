using Bank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.UserQueries
{
    public class GetUserPhotoQuery : IRequest<Photo>
    {
        public int UserId { get; set; }
        public GetUserPhotoQuery(int id)
        {
            UserId = id;
        }
    }
}
