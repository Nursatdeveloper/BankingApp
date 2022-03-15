using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int UserId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentCategory { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentBytes { get; set; }
    }
}
