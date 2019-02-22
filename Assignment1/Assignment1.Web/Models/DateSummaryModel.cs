using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class DateSummaryModel
    {
        public string Date { get; set; }
        public Decimal Sum { get; set; }

        public DateSummaryModel(string date)
        {
            this.Date = date;
            this.Sum = 0;
        }
    }
}
