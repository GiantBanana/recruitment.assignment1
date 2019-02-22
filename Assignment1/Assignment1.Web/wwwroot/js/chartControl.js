$(document).ready(function () {

    loadDefaultChart();

    $(".datePicker").datepicker();
    $(".datePicker").datepicker("option", "dateFormat", "yy-mm-dd");
    $("#loadingAlert").hide();


    $("#updateChartButton").click(function () {
        var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
        var data = $('form').serialize();

        updateChart(dataType, data);
    });
});

function loadDefaultChart() {
    $.ajax({
        url: "CompareRevenueAndCash",
        type: "GET",
        timeout: 30000,
        error: function () {
        },
        success: function (msg) {
            resetCanvas();
            var ctx = document.getElementById("results-chart").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ["Revenue", "Cash Flow"],
                    datasets: [{
                        label: "Revenue vs Cash Flow",
                        data: [msg[0], msg[1]],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255,99,132,1)',
                            'rgba(54, 162, 235, 1)'
                        ],
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

var updateChart = function (dataType, data) {
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
            var dates = new Array();
            var sums = new Array();
            var colors = new Array();


            msg.forEach(function (daySummary) {
                dates.push(daySummary.date);
                sums.push(daySummary.sum);
                colors.push(dynamicColors());

            });

            resetCanvas();

            var ctx = document.getElementById("results-chart").getContext('2d');

            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: dates,
                    datasets: [{
                        label: $("#selectView").find(":selected").text(),
                        data: sums,
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