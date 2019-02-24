$(document).ready(function() {
    $(".alert").hide();
    setUpDatePicker();
    $("#selectView").change(function () {
        console.log("#########################1");
        setUpDatePicker();
    });


});

var datesCannotBeNull = function() {
    const fromDate = $("#fromDate").val();
    const toDate = $("#toDate").val();

    if (fromDate === "" || toDate === "") {
        $("#datesCannotBeEmptyAlert").show();

        return false;
    }

    return true;
}

var startDateMustBeBeforeEndDate = function () {
    const fromDate = new Date($("#fromDate").val());
    const toDate = new Date($("#toDate").val());

    console.log(fromDate);
    console.log(toDate);


    if (fromDate >= toDate) {
        $("#fromDateMustBeBeforeAlert").show();
        return false;
    }
    return true;
}

var setUpDatePicker = function()
{
    const view = Number($("#selectView").find(":selected").val());

    $(".datePicker").datepicker("destroy");

    switch (view) {
        case 4:
            $("#toDate").hide();
            $("#toDate").datepicker().datepicker("setDate", new Date());
            $("#labelForToDate").hide();
            $("#labelForFromDate").html("Select year");

            $('.datePicker').datepicker({
                changeYear: true,
                dateFormat: 'yy',
                showButtonPanel: true,
                onClose: function () {
                    const  year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).datepicker('setDate', new Date(year, 1, 1));
                }
            });
            $(".datePicker").on("focus", function() {
                $(".ui-datepicker-calendar").hide();
                $(".ui-datepicker-month").hide();
            });
            break;
        default:
            $("#labelForToDate").show();
            $("#labelForFromDate").html("From");
            $("#toDate").show();
            $(".datePicker").off();
            $(".datePicker").datepicker({
                changeMonth: true,
                changeYear: true
            });
            $(".datePicker").datepicker("option", "dateFormat", "yy-mm-dd");
            break;
    }
    $(".datePicker").datepicker("refresh");


}