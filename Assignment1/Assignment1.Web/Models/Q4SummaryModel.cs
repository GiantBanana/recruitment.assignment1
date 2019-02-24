using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class Q4SummaryModel : FiscalQuarterSummaryModel
    {

        public Q4SummaryModel(string date)
        {
            this.TimePeriod = date;
            this.Sum = 0;
            this.Label = "Q4";
            this.Months = new List<int>() { 7, 8, 9 };

        }
    }
}
