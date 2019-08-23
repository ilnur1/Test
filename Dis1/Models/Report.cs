using System;
using System.Collections.Generic;

namespace Dis1.Models
{
    public partial class Report
    {
        public decimal Cr { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportWay { get; set; }
        public string ReportCustomer { get; set; }
        public string ReportStatus { get; set; }
        public decimal? Cc { get; set; }
        public string ReportName { get; set; }

        public Company CcNavigation { get; set; }
    }
}
