/// <reference path="../../../Scripts/jquery-1.5.1.min.js" />


$(document).ready(function () {
    $("#btnValidate").click(function () {
        $("#trainList img").hide();
        $("#trainList li").each(function () {
            var num1 = parseInt($(this).find("span.number:first").text());
            var num2 = parseInt($(this).find("span.number:last").text());
            var op = $(this).find("span.operator").text();
            var answer = $(this).find("input.tb").val();

            var correctAnswer = eval(num1 + op + num2);

            if (answer != correctAnswer) {
                $(this).find("img.imgwrong").show();
            }
            else {
                $(this).find("img.imgcorr").show();
            }
        });
    });
});

