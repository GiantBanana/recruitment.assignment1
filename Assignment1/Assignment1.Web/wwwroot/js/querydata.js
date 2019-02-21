$(document).ready(function () {

    loadDefaultChart();

    $(".datePicker").datepicker();

    $("#showHistogram").change(function() {
        if ($(this).is(":checked")) {
            $(".datePicker").removeAttr("disabled");
        } else {
            $(".datePicker").attr("disabled",true);

        }
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
            console.log(msg);
            var ctx = document.getElementById("myChart").getContext('2d');
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