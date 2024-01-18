using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace BulkyBook.Models.ViewModels
{
    public class ReportVM
    {
        public IConverter Converter { get; set; }
        public IRazorViewToStringRenderer Engine { get; set; }

    }

    public class OrderReportVM
    {
        public List<OrderHeader> OrderHeaders { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }

}
