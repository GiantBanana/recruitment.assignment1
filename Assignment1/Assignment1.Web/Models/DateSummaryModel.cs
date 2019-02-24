using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class DateSummaryModel : TimePeriodSummaryModel
    {

    public DateSummaryModel(string date)
    {
        this.TimePeriod = date;
        this.Sum = 0;
    }
    }
}
