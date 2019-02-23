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
        private readonly GetRevenueAllTime getRevenue;
        private readonly GetCashFlowAllTime getCashFlow;
        private readonly GetTimeSeriesDataSet getTimeSeries;

        public ReportingController(
            GetRevenueAllTime getRevenue,
            GetCashFlowAllTime getCashFlow,
            GetTimeSeriesDataSet getTimeSeries)
        {
            this.getRevenue = getRevenue;
            this.getCashFlow = getCashFlow;
            this.getTimeSeries = getTimeSeries;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("CompareRevenueAndCash")]
        public IActionResult CompareCashFlowAndRevenue()
        {
            var dateSummaryModels = new List<DateSummaryModel>()
            {
                (DateSummaryModel)getRevenue.GetTotal(),
                (DateSummaryModel)getCashFlow.GetTotal()
            };


            return new ObjectResult(dateSummaryModels);
        }

        [HttpPost("UpdateChart")]
        public IActionResult UpdateChart(RequestParametersModel parameters)
        {

            var dateSummaryModels = getTimeSeries.GetDataSet(parameters);

            return new ObjectResult(dateSummaryModels);
        }
    }
}