using Bank.Application.Commands.UserCommands;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<bool> Handle(AddUserPhotoCommand request, CancellationToken cancellationToken)
        {
            if (request.UserPhoto.Length <= 0)
            {
                return false;
            }

            string userId = JsonConvert.DeserializeObject<string>(request.UserId);
            Photo userPhoto = await _photoRepository.GetByUserIdAsync(Int32.Parse(userId));

            if(userPhoto == null)
            {
                using (var stream = new MemoryStream())
                {
                    await request.UserPhoto.CopyToAsync(stream);
                    userPhoto.UserId = Int32.Parse(userId);
                    userPhoto.PhotoBytes = stream.ToArray();
                }
                var photoResult = await _photoRepository.AddAsync(userPhoto);
                if(photoResult != null)
                {
                    return true;
                }
            }
            else
            {
                using (var stream = new MemoryStream())
                {
                    await request.UserPhoto.CopyToAsync(stream);
                    userPhoto.UserId = Int32.Parse(userId);
                    userPhoto.PhotoBytes = stream.ToArray();
                }
                await _photoRepository.UpdateAsync(userPhoto);
                return true;
            }
            return false;
        }
    }
}
