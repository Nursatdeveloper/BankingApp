using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services.PdfService
{
    public class PdfService : IPdfService
    {
        public byte[] GetPdfBytes(string html)
        {
            byte[] pdfFileBytes;
            using (var stream = new MemoryStream())
            using (var writer = new PdfWriter(stream))
            {
                string FONT_TIMES = @".\resources\fonts\times.ttf";


                string baseUri = @".\resources\static";
                ConverterProperties properties = new ConverterProperties();
                FontProvider fontProvider = new DefaultFontProvider(false, false, false);
                FontProgram fontProgram = FontProgramFactory.CreateFont(FONT_TIMES);
                fontProvider.AddFont(fontProgram);
                properties.SetFontProvider(fontProvider);
                properties.SetBaseUri(baseUri);
                HtmlConverter.ConvertToPdf(html, writer, properties);

                pdfFileBytes = stream.ToArray();
            }
            return pdfFileBytes;
        }
    }
}
