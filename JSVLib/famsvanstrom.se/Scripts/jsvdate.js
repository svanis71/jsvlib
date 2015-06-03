function JsvDateTime() {
    var dateSections = document.getElementsByClassName("jsvdate-date");
    var timeSections = document.getElementsByClassName("jsvdate-time");
    var _show = function JsvDateTime__show() {
        var time = new Date();
        var curDate = time.getFullYear() + "-" + (time.getMonth() + 1).toString().padLeft("0", 2) + "-" + time.getDate().toString().padLeft("0", 2);
        var curTime = time.getHours().toString().padLeft("0", 2) + ":" + time.getMinutes().toString().padLeft("0", 2) + ":" + time.getSeconds().toString().padLeft("0", 2);
        for (var i = 0; i < dateSections.length; i++) {
            dateSections[i].innerText = curDate;
        }
        for (var j = 0; j < timeSections.length; j++) {
            timeSections[j].innerText = curTime;
        }
        setTimeout(function () { _show(); }, 1000);
    };
    return {
        show: _show
    };
};