using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class Q1SummaryModel : FiscalQuarterSummaryModel

    {
        
        public Q1SummaryModel(string date)
        {
            this.TimePeriod = date;
            this.Sum = 0;
            this.Label = "Q1";
            this.Months = new List<int>() { 10, 11, 12 };
        }


    }
}
