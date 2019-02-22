using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Web.Models;
using Assignment1.Web.Repository;

namespace Assignment1.Web.Business
{
    public class GetTimeSeriesDataSet : IGetDataSet<DateSummaryModel>
    {
        private readonly ConvertFromStringToDateTimeObject convertFromStringToDate;
        private readonly ConvertFromDateTimeObjectsToString convertFromDateTimeToString;
        private readonly IGetData<TransactionModel> getData;



        public GetTimeSeriesDataSet(
            ConvertFromStringToDateTimeObject convertFromStringToDate, 
            ConvertFromDateTimeObjectsToString convertFromDateTimeToString, 
            IGetData<TransactionModel> getData)
        {
            this.convertFromStringToDate = convertFromStringToDate;
            this.convertFromDateTimeToString = convertFromDateTimeToString;
            this.getData = getData;
        }

        public List<DateSummaryModel> GetDataSet(object containsDate)
        {
            var requestParameters = (RequestParametersModel) containsDate;
            var fromDate = (DateTime) convertFromStringToDate.ProcessDate(requestParameters.FromDate);
            var fromDateCopy = (DateTime)convertFromStringToDate.ProcessDate(requestParameters.FromDate);
            var toDate = (DateTime) convertFromStringToDate.ProcessDate(requestParameters.ToDate);

            var dateSummaryModels = new List<DateSummaryModel>();
    

            for (var i = fromDate.Date.Ticks; i <= toDate.Date.Ticks; i+=TimeSpan.TicksPerDay)
            {
                dateSummaryModels.Add(new DateSummaryModel(
                    (string) convertFromDateTimeToString.ProcessDate(fromDate.AddTicks(i - fromDate.Ticks))
                        
                    ));

                fromDate = fromDateCopy;
            }

            switch (requestParameters.View)
            {
                case 0:
                    dateSummaryModels = GetCashFlowTimeSeries(dateSummaryModels);
                    break;
                case 1:
                    dateSummaryModels = GetFreeTransactionsTimeSeries(dateSummaryModels);
                    break;
                case 2:
                    dateSummaryModels = GetPaidTransactionsTimeSeries(dateSummaryModels);
                    break;
                case 3:
                    dateSummaryModels = GetCreditTransactionsTimeSeries(dateSummaryModels);
                    break;
            }

            return dateSummaryModels;
        }

        private List<DateSummaryModel> GetCashFlowTimeSeries(List<DateSummaryModel> dateSummaryModels)
        {
            var transactionModels = getData.GetData();
            var dateTime1 = new DateTime();
            var dateTime2 = new DateTime();


            foreach (var transactionModel in transactionModels)
            {

                if (transactionModel.PaidAt != null)
                {
                    dateTime1 = (DateTime)convertFromStringToDate.ProcessDate(transactionModel.GetPaidAtDateOnly());

                    foreach (var dateSummaryModel in dateSummaryModels)
                    {
                        dateTime2 = (DateTime)convertFromStringToDate.ProcessDate(dateSummaryModel.Date);

                        if (dateTime1.Date.Ticks == dateTime2.Date.Ticks)
                        {
                            dateSummaryModel.Sum = dateSummaryModel.Sum + transactionModel.Total;
                        }
                    }
                }

                

            }

            return dateSummaryModels;
        }

        private List<DateSummaryModel> GetFreeTransactionsTimeSeries(List<DateSummaryModel> dateSummaryModels)
        {
            var transactionModels = getData.GetData();
            var dateTime1 = new DateTime();
            var dateTime2 = new DateTime();


            foreach (var transactionModel in transactionModels)
            {

                if (transactionModel.PaidAt != null)
                {
                    dateTime1 = (DateTime)convertFromStringToDate.ProcessDate(transactionModel.GetPaidAtDateOnly());

                    foreach (var dateSummaryModel in dateSummaryModels)
                    {
                        dateTime2 = (DateTime)convertFromStringToDate.ProcessDate(dateSummaryModel.Date);

                        if (dateTime1.Date.Ticks == dateTime2.Date.Ticks && transactionModel.Total == 0)
                        {
                            dateSummaryModel.Sum = dateSummaryModel.Sum + 1;
                        }
                    }
                }

            }

            return dateSummaryModels;
        }

        private List<DateSummaryModel> GetPaidTransactionsTimeSeries(List<DateSummaryModel> dateSummaryModels)
        {
            var transactionModels = getData.GetData();
            var dateTime1 = new DateTime();
            var dateTime2 = new DateTime();


            foreach (var transactionModel in transactionModels)
            {

                if (transactionModel.PaidAt != null)
                {
                    dateTime1 = (DateTime)convertFromStringToDate.ProcessDate(transactionModel.GetPaidAtDateOnly());

                    foreach (var dateSummaryModel in dateSummaryModels)
                    {
                        dateTime2 = (DateTime)convertFromStringToDate.ProcessDate(dateSummaryModel.Date);

                        if (dateTime1.Date.Ticks == dateTime2.Date.Ticks && transactionModel.Total > 0)
                        {
                            dateSummaryModel.Sum = dateSummaryModel.Sum + 1;
                        }
                    }
                }

            }

            return dateSummaryModels;
        }


        private List<DateSummaryModel> GetCreditTransactionsTimeSeries(List<DateSummaryModel> dateSummaryModels)
        {
            var transactionModels = getData.GetData();
            var dateTime1 = new DateTime();
            var dateTime2 = new DateTime();


            foreach (var transactionModel in transactionModels)
            {

                dateTime1 = (DateTime)convertFromStringToDate.ProcessDate(transactionModel.GetCreatedAtDateOnly());

                foreach (var dateSummaryModel in dateSummaryModels)
                {
                    dateTime2 = (DateTime)convertFromStringToDate.ProcessDate(dateSummaryModel.Date);

                    if (dateTime1.Date.Ticks == dateTime2.Date.Ticks && transactionModel.Total < 0)
                    {
                        dateSummaryModel.Sum = dateSummaryModel.Sum + 1;
                    }
                }

            }

            return dateSummaryModels;
        }

    }
}
