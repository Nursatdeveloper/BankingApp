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
        Image GenerateDocumentHeader();
        Cell GetBankLogo();
        Cell CreateTextCell(string text, int fontSize);
    }
}
