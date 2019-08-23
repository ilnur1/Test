using System;
using System.Collections.Generic;

namespace Dis1.Models
{
    public partial class Shablon
    {
        public decimal Cs { get; set; }
        public string ShablonName { get; set; }
        public string ShablonPosition { get; set; }
        public string ShablonOrder { get; set; }
        public string ShablonAgent { get; set; }
        public decimal? Cc { get; set; }

        public Company CcNavigation { get; set; }
    }
}
