using System;
using System.Collections.Generic;
using Assignment1.Web.Models;
using Assignment1.Web.Repository;

namespace Assignment1.Web.Business
{
    public class GetRevenueAllTime : IGetSummaryTotal
    {
        private readonly IGetData<TransactionModel> getData;

        public GetRevenueAllTime(IGetData<TransactionModel> getData)
        {
            this.getData = getData;
        }

        public object GetTotal()
        {
            var transactions = getData.GetData();

            var dateSummary = new DateSummaryModel(
                    "RevenueAllTime"
                );

            foreach (var transaction in transactions)
            {
                if (transaction.Total > 0)
                {
                    dateSummary.Sum = dateSummary.Sum + transaction.Total;
                }
            }

            return dateSummary;
        }
    }
}
