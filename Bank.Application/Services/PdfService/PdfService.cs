using iText.IO.Image;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services.PdfService
{
    public class PdfService : IPdfService
    {
        public Image GenerateDocumentHeader()
        {
            Image image = new Image(ImageDataFactory
            .Create(@".\resources\images\logo.jpg"))
            .SetFixedPosition(220, 680)
            .SetWidth(150)
            .SetHeight(150);
            return image;         
        }

        public Cell GetBankLogo()
        {
            Image img = new Image(ImageDataFactory
                .Create(@".\resources\images\logo.jpg"))
                .SetWidth(150)
                .SetMarginLeft(180)
                .SetHeight(150);
            Cell cell = new Cell().Add(img);
            cell.SetBorder(Border.NO_BORDER);
            return cell;
        }

        public Cell CreateTextCell(string text, int fontSize)
        {
            Paragraph paragraph = new Paragraph(text)
                .SetFontSize(fontSize)
                .SetTextAlignment(TextAlignment.CENTER)
                ;
            Cell cell = new Cell()
                .Add(paragraph)
                .SetBorder(Border.NO_BORDER);
            return cell;
        }
    }
}
