using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class Q2SummaryModel : FiscalQuarterSummaryModel
    {

        public Q2SummaryModel(string date)
        {
            
            this.TimePeriod = date;
            this.Sum = 0;
            this.Label = "Q2";
            this.Months = new List<int>() { 1, 2, 3 };

        }
    }
}
