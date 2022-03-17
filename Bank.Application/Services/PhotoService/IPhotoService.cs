using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services.PhotoService
{
    public interface IPhotoService
    {
        byte[] GetBase64Image(byte[] photoBytes);
    }
}
