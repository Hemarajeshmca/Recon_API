using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ReconDataLayer
{
    public class PdfWatermarkHandler : PdfPageEventHelper
    {
        private Image _watermarkImage;

        //public PdfWatermarkHandler(Image watermarkImage)
        //{
        //    _watermarkImage = watermarkImage;
        //}

		public override void OnEndPage(PdfWriter writer, Document document)
        {
			PdfContentByte content = writer.DirectContent;
			Rectangle rectangle = new Rectangle(document.PageSize);
			rectangle.Left += document.LeftMargin - 20;
			rectangle.Right -= document.RightMargin - 20;
			rectangle.Top -= document.TopMargin - 30;
			rectangle.Bottom += document.BottomMargin - 30;
			//content.SetColorStroke(BaseColor.GRAY); // Setting the color of the border to gray
			//content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
			content.Stroke();

			//PdfContentByte canvas = writer.DirectContentUnder;
			//_watermarkImage.SetAbsolutePosition(
			//    (document.PageSize.Width - _watermarkImage.ScaledWidth) / 2,
			//    (document.PageSize.Height - _watermarkImage.ScaledHeight) / 2
			//);
			//canvas.AddImage(_watermarkImage);
		}
    }

}
