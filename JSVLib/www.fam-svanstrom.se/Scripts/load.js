$(function () {
    $("#logonDialog").dialog({
        autoOpen: false,
        modal: true,
        title: "Inloggning",
        width: 660,
        height: 230
    });
    $("#q").on("focus", function () {
        if ($(this).val() == "Sök") {
            $(this).val("");
        }
        $(this).removeClass("q-empty");
    })
        .on("blur", function () {
            if ($(this).val() == "" || $(this).val() == "Sök") {
                $(this).val("Sök");
                $(this).addClass("q-empty");
            }
            $(this).removeClass("q-active");
        });
    $("#arrowLabel").on("click", function() {
        $("#arrow").click();
    });
    $("#arrow").on("click", function() {
        if ($(this).hasClass("arrow-down")) {
            $(this).removeClass("arrow-down").addClass("arrow-up");
            $("#arrowLabel").text("Dölj meny");
            $("#nav").show();
        } else {
            $(this).addClass("arrow-down").removeClass("arrow-up");
            $("#arrowLabel").text("Visa meny");
            $("#nav").hide();
        }
    });
    //$.getJSON("/Startpage/Getmenuitems", function(data) {
    //    $("#nav").jsvMenu(data);
    //});
    //$.ajax({
    //    url: "/StartPage/GetMenuItems",
    //    dataType: "json"
    //}).done(function(data) {
    //    $("#nav").jsvMenu(data);
    //});
});
