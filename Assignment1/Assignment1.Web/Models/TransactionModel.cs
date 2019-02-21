using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Models
{
    public class TransactionModel
    {
        public Decimal Total { get; set; }
        public string CreatedAt { get; set; }
        public string PaidAt { get; set; }
    }
}
