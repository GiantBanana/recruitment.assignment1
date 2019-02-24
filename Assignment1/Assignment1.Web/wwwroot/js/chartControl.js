$(document).ready(function () {

    loadDefaultChart();

    $("#updateChartButton").click(function () {
        const view = $("#selectView").find(":selected");

        $(".alert").hide();
        if (!datesCannotBeNull() || !startDateMustBeBeforeEndDate()) {
            return;
        }


        const  dataType = 'application/x-www-form-urlencoded; charset=utf-8';
        const data = $('form').serialize();

        switch (Number(view.val())) {
            case 4:
                getQuarterlyReport(dataType, data, view.text());
                break;
            default:
                updateChart(dataType, data, view.text());
                break;
        }

    });
});



var  loadDefaultChart = function () {
    $.ajax({
        url: "CompareRevenueAndCash",
        type: "GET",
        timeout: 30000,
        error: function () {
        },
        success: function (msg) {

            var labels = new Array();
            var data = new Array();
            var colors = new Array();


            msg.forEach(function (daySummary) {
                labels.push(daySummary.timePeriod);
                data.push(daySummary.sum);
                colors.push(dynamicColors());

            });

            resetCanvas();
            const  ctx = document.getElementById("results-chart").getContext('2d');
            const  myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: "Revenue vs Cash Flow",
                        data: data,
                        backgroundColor: colors,
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }
    });
}

var updateChart = function (dataType, data, chartLabel) {
    $("#loadingAlert").fadeTo(2000, 500).slideUp(500, function () {
        $("#loadingAlert").slideUp(500);
    });
    $.ajax({
        url: "UpdateChart",
        type: "POST",
        dataType: "json",
        contentType: dataType,
        data: data,
        timeout: 30000,
        error: function () {

        },
        success: function (msg) {
            var labels = new Array();
            var data = new Array();

            msg.forEach(function (daySummary) {
                labels.push(daySummary.timePeriod);
                data.push(daySummary.sum);
            });

            resetCanvas();

            const  ctx = document.getElementById("results-chart").getContext('2d');
            const  myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: labels,
                    datasets: [{
                        label: chartLabel,
                        data: data,
                        backgroundColor: "rgb(66, 133, 244)"
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }
    });
}


var getQuarterlyReport = function (dataType, data, chartLabel) {

    $.ajax({
        url: "QuarterlyReport",
        type: "POST",
        dataType: "json",
        contentType: dataType,
        data: data,
        timeout: 30000,
        error: function () {

        },
        success: function (msg) {
            var labels = new Array();
            var data = new Array();
            var colors = new Array();


            msg.forEach(function (quarterSummary) {
                labels.push(quarterSummary.label);
                data.push(quarterSummary.sum);
                colors.push(dynamicColors());

            });

            resetCanvas();

            const ctx = document.getElementById("results-chart").getContext('2d');
            const myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: chartLabel + " " + msg[0].timePeriod,
                        data: data,
                        backgroundColor: colors
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }
    });
};

var resetCanvas = function () {
    $("#results-chart").remove();
    $('.chart-container').append('<canvas id="results-chart"><canvas>');

};

var dynamicColors = function () {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);
    return "rgb(" + r + "," + g + "," + b + ")";
};