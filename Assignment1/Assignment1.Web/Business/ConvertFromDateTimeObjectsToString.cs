using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Web.Models;
using Microsoft.Extensions.Options;

namespace Assignment1.Web.Business
{
    public class ConvertFromDateTimeObjectsToString : IProcessDate
    {
        private readonly DateTimeSettings dateTimeSettings;

        public ConvertFromDateTimeObjectsToString(IOptionsMonitor<DateTimeSettings> optionsAccessor)
        {
            this.dateTimeSettings = optionsAccessor.CurrentValue;
        }

        public object ProcessDate(object containsDate)
        {
            var dateTime = (DateTime) containsDate;
            var dateString = dateTime.Date.ToString(dateTimeSettings.DateTimePattern);
            return dateString;
        }
    }
}
