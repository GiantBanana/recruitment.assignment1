using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Web.Models;
using Assignment1.Web.Repository;

namespace Assignment1.Web.Business
{
    public class QueryData
    {
        private readonly IGetData<TransactionModel> getData;

        public QueryData(IGetData<TransactionModel> getData)
        {
            this.getData = getData;
        }

        public Decimal GetSumPaidTransactions()
        {
            List<TransactionModel> transactions = getData.GetData();

            Decimal sum = 0;

            foreach (var transaction in transactions)
            {
                if (transaction.PaidAt != null)
                {
                    sum = sum + transaction.Total;
                }   
            }

            return Decimal.Round(sum,2);
        }

        public Decimal GetSumAllTransactions()
        {
            List<TransactionModel> transactions = getData.GetData();

            Decimal sum = 0;

            foreach (var transaction in transactions)
            {
                sum = sum + transaction.Total;
            }

            return Decimal.Round(sum, 2);
        }
    }
}
