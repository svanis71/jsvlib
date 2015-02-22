/// <reference path="../../../Scripts/jquery-1.5.1.min.js" />


$(document).ready(function () {
    $("#dlgResult").dialog({
        autoOpen: false, title: "Matteträning",
        buttons: [{ text: "Ok", click: function () { $(this).dialog('close') } }]
    });
    $(".trainList li input.tb").blur(function () {
        $(this).nextAll("img").hide();
    });
    $(".trainList li:first input.tb").focus();
    $("#btnValidate").click(function () {
        $("#trainList img").hide();
        var correctAnswers = 0;
        var totQuestions = 0;
        $(".trainList li").each(function () {
            var num1 = parseInt($(this).find("span.number:first").text());
            var num2 = parseInt($(this).find("span.number:last").text());
            var op = $(this).find("span.operator:first").text();
            var answer = parseInt($(this).find("input.tb").val());
            var correctAnswer = parseInt(eval(num1 + op + num2));

            if (answer != correctAnswer) {
                $(this).find("img.imgwrong").show();
            }
            else {
                $(this).find("img.imgcorr").show();
                correctAnswers++;
            }
            totQuestions++;
        });
        $("#pReport").text("Du hade " + correctAnswers + " rätt av " + totQuestions + " möjliga.");
        $("#dlgResult").dialog('open');
    });
});

