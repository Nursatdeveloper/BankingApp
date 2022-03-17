using Bank.Application.Commands.UserCommands;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserCommandHandlers
{
    public class AddUserPhotoHandler : IRequestHandler<AddUserPhotoCommand, bool>
    {
        private readonly IPhotoRepository _photoRepository;
        public AddUserPhotoHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public Task<bool> Handle(AddUserPhotoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
