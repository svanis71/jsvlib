function PersonnummerGenerator() {

    this.generateSsn = function(n) {
        var today = new Date();
        var ssnArr = new Array();
        var lblTotal = document.getElementById("lblTotal");
        var maxDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        lblTotal.firstChild.nodeValue = n;
        this.showProgress(0);

        while (--n >= 0) {
            var year = this.random(1910, today.getFullYear() - 6).toString();
            var month = this.random(1, 12).toString();
            var day = this.random(1, maxDays[month - 1]).toString();
            var last4 = this.random(1000, 9999).toString();

            if (month.length < 2)
                month = "0" + month;
            if (day.length < 2)
                day = "0" + day;

            var ssn = year + month + day + "-" + last4;
            var modulo10 = this.getModulo10(ssn);

            if (modulo10 != 0) {
                var origLast = last4.charAt(3) * 1;
                var last = (origLast + 10 - modulo10) % 10;
                ssn = ssn.substring(0, 12) + last;
            }
            ssnArr.push(ssn);
        }
        ssnArr.sort();
        return ssnArr;
    };

    this.getModulo10 = function(ssnToTest) {
        var ssn = ssnToTest.replace(/-/, "");
        if (ssn.match(/\d{4}(1[0-2]|0[0-9])([0-2][0-9]|3[0-1])\d{4}/) == null)
            return -99;

        var multiplier = 2;
        var checkSum = 0;

        ssn = ssn.toString().substring(2, 12);

        for (var i = 0; i < 10; i++) {
            var tmp = parseInt(ssn.charAt(i)) * multiplier;
            if (tmp > 9)
                tmp -= 9;
            checkSum += tmp;
            multiplier = 3 - multiplier;
        }

        return checkSum % 10;
    };


    this.showProgress = function(curIdx) {
        var lblCurrent = document.getElementById("lblCurrent");
        var prog = document.getElementById("divProgress");

        if (prog.style.display != "")
            prog.style.display = "";

        lblCurrent.nodeText = curIdx;
        if (prog.className = "" || prog.className == "normal")
            prog.className = "yellow";
        else
            prog.className = "normal";
    };

    this.stopProgress = function() {
        var prog = document.getElementById("divProgress");
        prog.style.display = "none";
    };

    this.random = function(min, max) {
        if (min > max)
            return NaN;

        var mult = max - min;
        var rnd = Math.floor((Math.random() * mult));
        return min + rnd;
    };

}
