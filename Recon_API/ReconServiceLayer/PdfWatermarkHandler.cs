using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ReconDataLayer
{
    public class PdfWatermarkHandler : PdfPageEventHelper
    {

        private string _logoPath;
        private PdfTemplate total;
        private BaseFont baseFont;
        private DateTime printTime;
        public PdfWatermarkHandler(string logoPath)
        {
            _logoPath = logoPath;
            printTime = DateTime.Now;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            total = writer.DirectContent.CreateTemplate(50, 50);
            baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte content = writer.DirectContent;

            // Page number and date/time
           // string text = $"Page: {writer.PageNumber} / ";
           // string dateText = $"Date: {printTime.ToString()}";
            // var combinedPhrase = new Phrase($"{text}    -  {dateText}", new Font(baseFont, 8));
          //  var combinedPhrase = new Phrase(text, new Font(baseFont, 8));
           // var datePhrase = new Phrase(dateText, new Font(baseFont, 8));
           // float adjust = 50; // Adjustment for total pages template

           // float textBase = document.Bottom - 20;
          //  ColumnText.ShowTextAligned(content, Element.ALIGN_LEFT, combinedPhrase, document.LeftMargin, textBase, 0);
          //  ColumnText.ShowTextAligned(content, Element.ALIGN_LEFT, datePhrase, document.LeftMargin + adjust, textBase, 0);
          //  float len = baseFont.GetWidthPoint(text, 8);
         //   content.AddTemplate(total, document.LeftMargin + len, textBase);
            
            // Logo
            if (File.Exists(_logoPath))
            {
                Image logo = Image.GetInstance(_logoPath);
                logo.ScaleToFit(50, 50); // Adjust logo size
                float xPosition = document.PageSize.Width - document.RightMargin - logo.ScaledWidth;
                float yPosition = document.Bottom - 20;
                logo.SetAbsolutePosition(xPosition, yPosition);
                content.AddImage(logo);
            }
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            if (total != null)
            {
                total.BeginText();
                total.SetFontAndSize(baseFont, 8);
                total.SetTextMatrix(0, 0);
                //total.ShowText((writer.PageNumber - 1).ToString());
                total.ShowText($"{writer.PageNumber - 1}");
                total.EndText();
            }
            else
            {
                Console.WriteLine("Total template is not initialized when closing document.");
            }
        }
        //      public override void OnEndPage(PdfWriter writer, Document document)
        //      {
        //	PdfContentByte content = writer.DirectContent;
        //	Rectangle rectangle = new Rectangle(document.PageSize);
        //	rectangle.Left += document.LeftMargin - 20;
        //	rectangle.Right -= document.RightMargin - 20;
        //	rectangle.Top -= document.TopMargin - 30;
        //	rectangle.Bottom += document.BottomMargin - 30;
        //          var pageNumberPhrase = new Phrase($"Page {writer.PageNumber}", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //          var datePhrase = new Phrase(DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8));

        //          ColumnText.ShowTextAligned(content, Element.ALIGN_LEFT, pageNumberPhrase, document.LeftMargin, document.Bottom - 20, 0);
        //          ColumnText.ShowTextAligned(content, Element.ALIGN_LEFT, datePhrase, document.LeftMargin, document.Bottom - 30, 0);

        //          if (File.Exists(_logoPath))
        //          {
        //              Image logo = Image.GetInstance(_logoPath);
        //              logo.SetAbsolutePosition(document.PageSize.Width - document.RightMargin - logo.ScaledWidth, document.Bottom - 20);
        //              content.AddImage(logo);
        //          }

        //          //content.SetColorStroke(BaseColor.GRAY); // Setting the color of the border to gray
        //          //content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
        //          //content.Stroke();

        //	//PdfContentByte canvas = writer.DirectContentUnder;
        //	//_watermarkImage.SetAbsolutePosition(
        //	//    (document.PageSize.Width - _watermarkImage.ScaledWidth) / 2,
        //	//    (document.PageSize.Height - _watermarkImage.ScaledHeight) / 2
        //	//);
        //	//canvas.AddImage(_watermarkImage);
        //}

    }

}
