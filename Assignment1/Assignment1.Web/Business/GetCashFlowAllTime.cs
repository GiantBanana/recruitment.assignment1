using Assignment1.Web.Models;
using Assignment1.Web.Repository;

namespace Assignment1.Web.Business
{
    public class GetCashFlowAllTime : IGetSummaryTotal
    {
        private readonly IGetData<TransactionModel> _getData;

        public GetCashFlowAllTime(IGetData<TransactionModel> getData)
        {
            this._getData = getData;
        }

        public object GetTotal()
        {
            var transactions = _getData.GetData();

            var dateSummary = new DateSummaryModel(
                    "CashFlowAllTime"
                );

            foreach (var transaction in transactions)
            {
                if (transaction.PaidAt != null)
                {
                    dateSummary.Sum = dateSummary.Sum + transaction.Total;
                }
            }

            return dateSummary;
        }
    }
}
