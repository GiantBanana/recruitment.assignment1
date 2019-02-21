using System;

namespace Assignment1.Web.Models
{
    public class TransactionModel
    {
        public Decimal Total { get; set; }
        public string CreatedAt { get; set; }
        public string PaidAt { get; set; }
    }
}
