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
