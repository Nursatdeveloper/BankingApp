using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public int UserId { get; set; }
        public byte[] PhotoBytes { get; set; }
    }
}
