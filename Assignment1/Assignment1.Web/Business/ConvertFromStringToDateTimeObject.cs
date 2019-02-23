using System;
using Assignment1.Web.Models;
using Microsoft.Extensions.Options;

namespace Assignment1.Web.Business
{
    public class ConvertFromStringToDateTimeObject : IProcessDate
    {
        private readonly DateTimeSettings dateTimeSettings;

        public ConvertFromStringToDateTimeObject(IOptionsMonitor<DateTimeSettings> optionsAccessor)
        {
            this.dateTimeSettings = optionsAccessor.CurrentValue;
        }

        public object ProcessDate(object containsDate)
        {
            var dateTime = DateTime.ParseExact(
                (string) containsDate,
                dateTimeSettings.DateTimePattern,
                System.Globalization.CultureInfo.InvariantCulture);


            return dateTime;
        }
    }
}
