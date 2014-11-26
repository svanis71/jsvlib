$(function () {
    $("div.showMenuIcon").on("click", function () {
        var menuToShow = $(this).data("menuid");
        var action = $(this).data("action");
        if (action == "show") {
            $("#" + menuToShow).show();
            $(this).data("action", "hide");
            $(this).text("Dölj menyn");
        } else {
            $("#" + menuToShow).hide();
            $(this).data("action", "show");
            $(this).text("Visa menyn");
        }
    });

    $("dd.topmenuItem").on("mouseover", function () {
        $(this).find(".dropdown").show();
    })
      .on("mouseleave", function () {
          $(this).find(".dropdown").hide();
      });

    $(window).resize(function(e) {
        var w = $(window).width();
        var h = $(window).height();
        var code = "<span class='footText'>Width = " + w + ", Height = " + h + "</span>";
        console.log(code);
        $("footer section#middleFoot").html(code);
    });
});