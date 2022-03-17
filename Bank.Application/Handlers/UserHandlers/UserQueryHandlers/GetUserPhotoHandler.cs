using Bank.Application.Queries.UserQueries;
using Bank.Application.Services.PhotoService;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserQueryHandlers
{
    public class GetUserPhotoHandler : IRequestHandler<GetUserPhotoQuery, Photo>
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoService _photoService;
        public GetUserPhotoHandler(IPhotoRepository photoRepository, IPhotoService photoService)
        {
            _photoRepository = photoRepository;
            _photoService = photoService;
        }
        public async Task<Photo> Handle(GetUserPhotoQuery request, CancellationToken cancellationToken)
        {

            Photo userPhoto = await _photoRepository.GetByUserIdAsync(request.UserId);
            userPhoto.PhotoBytes = _photoService.GetBase64Image(userPhoto.PhotoBytes);
            return userPhoto;
        }
    }
}
