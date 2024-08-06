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
	public class PdfFooter : PdfPageEventHelper
	{
		private PdfContentByte cb;
		private PdfTemplate template;
		private BaseFont bf = null;
		private DateTime printTime = DateTime.Now;
		private string _logoPath;
		public PdfFooter(string logoPath)
		{
			_logoPath = logoPath;
			printTime = DateTime.Now;
			PdfTemplate total;
		}
		public override void OnOpenDocument(PdfWriter writer, Document document)
		{
			cb = writer.DirectContent;
			template = cb.CreateTemplate(50, 50);
			bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
		}

		public override void OnEndPage(PdfWriter writer, Document document)
		{
			PdfContentByte content = writer.DirectContent;
			Rectangle rectangle = new Rectangle(document.PageSize);
			rectangle.Left += document.LeftMargin - 20;
			rectangle.Right -= document.RightMargin - 20;
			rectangle.Top -= document.TopMargin - 30;
			rectangle.Bottom += document.BottomMargin - 30;

			int pageN = writer.PageNumber;
			String text = "Page " + pageN + " of ";
			String dateTimeText = "      -    " + printTime.ToString();
			float len = bf.GetWidthPoint(text + "  " + dateTimeText, 8);
			cb.BeginText();
			cb.SetFontAndSize(bf, 8);
			cb.SetTextMatrix(document.LeftMargin, document.PageSize.GetBottom(10));
			cb.ShowText(text);
			cb.EndText();
			cb.AddTemplate(template, document.LeftMargin + bf.GetWidthPoint(text, 8), document.PageSize.GetBottom(10));

			cb.BeginText();
			cb.SetFontAndSize(bf, 8);
			cb.SetTextMatrix(document.LeftMargin + len - bf.GetWidthPoint(dateTimeText, 8), document.PageSize.GetBottom(10));
			cb.ShowText(dateTimeText);
			cb.EndText();

			if (File.Exists(_logoPath))
			{
				Image logo = Image.GetInstance(_logoPath);
				logo.ScaleToFit(50, 50); // Adjust logo size
				float xPosition = document.PageSize.Width - document.RightMargin - logo.ScaledWidth;
				float yPosition = document.Bottom - 20;
				logo.SetAbsolutePosition(xPosition, yPosition);
				content.AddImage(logo);
			}
			content.SetColorStroke(BaseColor.GRAY);
			content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
			content.Stroke();
		}

		public override void OnCloseDocument(PdfWriter writer, Document document)
		{
			template.BeginText();
			template.SetFontAndSize(bf, 8);
			template.SetTextMatrix(0, 0);
			template.ShowText(" " + (writer.PageNumber));
			template.EndText();
		}
	}
}