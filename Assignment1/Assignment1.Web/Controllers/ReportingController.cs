using System.Collections.Generic;
using Assignment1.Web.Business;
using Assignment1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Web.Controllers
{
    public class ReportingController : Controller
    {
        private readonly GetRevenueAllTime _getRevenue;
        private readonly GetCashFlowAllTime _getCashFlow;
        private readonly IGetDataSet<DateSummaryModel> _getTimeSeries;
        private readonly IGetDataSet<FiscalQuarterSummaryModel> _getQuarterlyReport;

        public ReportingController(
            GetRevenueAllTime getRevenue,
            GetCashFlowAllTime getCashFlow,
            IGetDataSet<DateSummaryModel> getTimeSeries,
            IGetDataSet<FiscalQuarterSummaryModel> getQuarterlyReport)
        {
            this._getRevenue = getRevenue;
            this._getCashFlow = getCashFlow;
            this._getTimeSeries = getTimeSeries;
            this._getQuarterlyReport = getQuarterlyReport;
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
                (DateSummaryModel)_getRevenue.GetTotal(),
                (DateSummaryModel)_getCashFlow.GetTotal()
            };


            return new ObjectResult(dateSummaryModels);
        }

        [HttpPost("UpdateChart")]
        public IActionResult UpdateChart(RequestParametersModel parameters)
        {

            var dateSummaryModels = _getTimeSeries.GetDataSet(parameters);

            return new ObjectResult(dateSummaryModels);
        }

        [HttpPost("QuarterlyReport")]
        public IActionResult QuarterlyReport(RequestParametersModel parameters)
        {

            return new ObjectResult(_getQuarterlyReport.GetDataSet(parameters));
        }
    }
}