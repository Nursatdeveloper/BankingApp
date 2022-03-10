using Bank.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Queries.UserQueries
{
    public class GetUserByTelephoneQuery : IRequest<UserResponse>
    {
        public string Telephone { get; set; }
        public GetUserByTelephoneQuery(string tel)
        {
            Telephone = tel;
        }
    }
}
