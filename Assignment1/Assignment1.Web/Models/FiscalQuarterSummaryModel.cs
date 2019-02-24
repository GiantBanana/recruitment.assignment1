using System.Collections.Generic;

namespace Assignment1.Web.Models
{
    public class FiscalQuarterSummaryModel : TimePeriodSummaryModel
    {

        public string Label { get; set; }
        public List<int> Months { get; set; }


    }
}
