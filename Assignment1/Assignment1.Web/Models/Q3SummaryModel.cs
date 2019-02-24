using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class Q3SummaryModel : FiscalQuarterSummaryModel
    {

        public Q3SummaryModel(string date)
        {
            this.TimePeriod = date;
            this.Sum = 0;
            this.Label = "Q3";
            this.Months = new List<int>() { 4, 5, 6 };

        }
    }
}
