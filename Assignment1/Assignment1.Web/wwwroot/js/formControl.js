$(document).ready(function() {
    $("#datesCannotBeEmptyAlert").hide();
    $("#fromDateMustBeBeforeAlert").hide();




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