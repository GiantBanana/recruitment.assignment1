using System;

namespace Assignment1.Web.Models
{
    public class TransactionModel
    {
        public Decimal Total { get; set; }
        public string CreatedAt { get; set; }
        public string PaidAt { get; set; }

        public string GetCreatedAtDateOnly()
        {
            var stringArray = this.CreatedAt.Split(null);

            return stringArray[0];
        }

        public string GetPaidAtDateOnly()
        {
            var stringArray = this.PaidAt.Split(null);

            return stringArray[0];
        }
    }
}
