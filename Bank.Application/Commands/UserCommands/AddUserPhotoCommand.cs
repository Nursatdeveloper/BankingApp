using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.UserCommands
{
    public class AddUserPhotoCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public IFormFile UserPhoto { get; set; }
    }
}
