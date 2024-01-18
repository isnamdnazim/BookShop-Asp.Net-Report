using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ReportService
    {
        public ReportService(Orientation orientation, PaperKind paperKind, MarginSettings marginSettings)
        {
            Orientation = orientation;
            PaperKind = paperKind;
            Margins = marginSettings;
        }
        public ReportService()
        {
            Orientation = Orientation.Portrait;
            PaperKind = PaperKind.A4;
            Margins = new MarginSettings { Top = 10 };
        }
        public string OutPath { get; set; }
        public string StylePath { get; set; }
        public string HtmlContent { get; set; }
        public Orientation Orientation { get; set; }
        public PaperKind PaperKind { get; set; }
        public MarginSettings Margins { get; set; }
        public GlobalSettings GlobalSettings
        {
            get
            {
                return new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    //Orientation = Orientation.Landscape,
                    Orientation = this.Orientation,
                    PaperSize = this.PaperKind,
                    Margins = this.Margins,
                    DPI = 300,
                    //DocumentTitle = "PDF Report",
                    Out = OutPath
                };
            }
            set
            {
            }
        }
        public ObjectSettings ObjectSettings
        {
            get
            {
                return new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = HtmlContent,//TemplateGenerator.GetHTMLString(),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = StylePath },
                    //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Right = "Page [page] of [toPage]" }
                };
            }
            set { }
        }

        public HtmlToPdfDocument PdfDocument
        {
            get
            {
                return new HtmlToPdfDocument()
                {
                    GlobalSettings = GlobalSettings,
                    Objects = { ObjectSettings }
                };
            }
            set { }

        }
    }
}
