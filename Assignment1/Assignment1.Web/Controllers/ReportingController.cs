using System;
using System.Collections.Generic;
using Assignment1.Web.Business;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Web.Controllers
{
    public class ReportingController : Controller
    {
        private readonly QueryData queryData;

        public ReportingController(QueryData queryData)
        {
            this.queryData = queryData;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("CompareRevenueAndCash")]
        public IActionResult CompareCashFlowAndRevenue()
        {
            List<Decimal> result = new List<Decimal>();
            result.Add(queryData.GetSumAllTransactions());
            result.Add(queryData.GetSumPaidTransactions());

            return new ObjectResult(result);
        }
    }
}