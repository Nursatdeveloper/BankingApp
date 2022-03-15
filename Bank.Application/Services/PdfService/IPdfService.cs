using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services.PdfService
{
    public interface IPdfService
    {
        byte[] GetPdfBytes(string html);
    }
}
