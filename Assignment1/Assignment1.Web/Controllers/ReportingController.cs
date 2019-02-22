using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assignment1.Web.Business;
using Assignment1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Web.Controllers
{
    public class ReportingController : Controller
    {
        private readonly QueryData queryData;
        private readonly GetTimeSeriesDataSet getTimeSeries;

        public ReportingController(
            QueryData queryData, 
            GetTimeSeriesDataSet getTimeSeries)
        {
            this.queryData = queryData;
            this.getTimeSeries = getTimeSeries;
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

        [HttpPost("UpdateChart")]
        public IActionResult UpdateChart(RequestParametersModel parameters)
        {

            var dateSummaryModels = getTimeSeries.GetDataSet(parameters);

            return new ObjectResult(dateSummaryModels);
        }
    }
}