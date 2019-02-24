using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Web.Business;

namespace Assignment1.Web.Models
{
    public class FiscalQuarterSummaryModel : TimePeriodSummaryModel
    {

        public string Label { get; set; }
        public List<int> Months { get; set; }


    }
}
