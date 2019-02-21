$(document).ready(function () {
    var url = window.location.href;
    url = url.substring(0, (url.indexOf("#") == -1) ? url.length : url.indexOf("#"));
    url = url.substring(0, (url.indexOf("?") == -1) ? url.length : url.indexOf("?"));
    url = url.substr(url.lastIndexOf("/") + 1);

    if (url == "") {
        url = "Home";
    }

    $(".sidenav a").removeClass("activeMenuItem");
    $(".sidenav a[url='" + url + "']").addClass("activeMenuItem");

    console.log(url);

});