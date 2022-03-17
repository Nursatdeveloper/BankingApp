using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        public byte[] GetBase64Image(byte[] photoBytes)
        {
            string base64String = Convert.ToBase64String(photoBytes);
            byte[] bytes = Convert.FromBase64String(base64String);
            return bytes;
        }
    }
}
