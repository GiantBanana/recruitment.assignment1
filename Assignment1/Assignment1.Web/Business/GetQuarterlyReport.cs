using System;
using System.Collections.Generic;
using Assignment1.Web.Models;
using Assignment1.Web.Repository;

namespace Assignment1.Web.Business
{
    public class GetQuarterlyReport : IGetDataSet<FiscalQuarterSummaryModel>
    {
        private readonly ConvertFromStringToDateTimeObject _fromStringToDate;
        private readonly IGetData<TransactionModel> _getData;



        public GetQuarterlyReport(
            ConvertFromStringToDateTimeObject fromStringToDate,
            IGetData<TransactionModel> getData)
        {
            this._fromStringToDate = fromStringToDate;
            this._getData = getData;
        }

        public List<FiscalQuarterSummaryModel> GetDataSet(object requestParams)
        {
            var containsDate = (RequestParametersModel) requestParams;

            var quarterSummaryModels = new List<FiscalQuarterSummaryModel>()
            {
                new Q1SummaryModel(containsDate.FromDate),
                new Q2SummaryModel(containsDate.FromDate),
                new Q3SummaryModel(containsDate.FromDate),
                new Q4SummaryModel(containsDate.FromDate)
            };

            return SumQuarters(quarterSummaryModels);
        }

        private List<FiscalQuarterSummaryModel> SumQuarters(List<FiscalQuarterSummaryModel> fiscalQuarterSummaryModels)
        {
            var transactionModels = _getData.GetData();


            foreach (var transactionModel in transactionModels)
            {
                var dateTime1 = (DateTime)_fromStringToDate.ProcessDate(transactionModel.GetCreatedAtDateOnly());

                foreach (var fiscalQuarterSummaryModel in fiscalQuarterSummaryModels)
                {

                    if (dateTime1.Year == int.Parse(fiscalQuarterSummaryModel.TimePeriod) 
                        && (dateTime1.Month == fiscalQuarterSummaryModel.Months[0] || dateTime1.Month == fiscalQuarterSummaryModel.Months[1] || dateTime1.Month == fiscalQuarterSummaryModel.Months[2]))
                    {
                        fiscalQuarterSummaryModel.Sum = fiscalQuarterSummaryModel.Sum + 1;
                    }
                }
            }

            return fiscalQuarterSummaryModels;
        }

    }

}
