/// <reference path="PersonnummerGenerator.js" />

function SsnMain() {
    this.createRandomSsn = function(n, div) {

        if (n > 10000) {
            if (!confirm('Vill du verkligen skapa ' + n + ' personnummer?'))
                return;
        }
        var timer = new StopWatch();

        var orgStatus = window.status;

        timer.start();

        var ssns = PersonnummerGenerator.generateSsn(n);

        //var div = document.getElementById("resDiv");
        var tabs = div.getElementsByTagName("table");

        div.style.display = "none";
        div.className = "ssnResult";

        if (tabs.length > 0) {
            try {
                div.removeChild(tabs[0]);

            } catch(e) {
                alert(e);
            }
        }


        var tab = document.createElement("table");
        tab.id = "ssnTable";
        tab.appendChild(document.createElement("tbody")); // Krävs av ie...
        for (var i = 0; i < ssns.length; i++) {
            var row = document.createElement("tr");
            row.className = i % 2 == 0 ? "evenRow" : "oddRow";
            var col = document.createElement("td");
            col.appendChild(document.createTextNode(ssns[i]));

            row.appendChild(col);
            tab.tBodies[0].appendChild(row);


            //        if ((i % 200) == 0)
            //            window.status = "Skapat " + i + " personnummer av " + n; ;
        }

        div.appendChild(tab);

        $(".timerStyle").remove();

        var timeDiv = $("#timerDiv");

        var timeResultElem = document.createElement("span");
        timeResultElem.className = "timerStyle";
        timeResultElem.appendChild(document.createTextNode(n + " personnummer skapade på " + timer.stop().duration() + " s."));

        timeDiv.append(timeResultElem);

        PersonnummerGenerator.stopProgress();
        div.style.display = "";
        window.status = orgStatus;
    };

};



