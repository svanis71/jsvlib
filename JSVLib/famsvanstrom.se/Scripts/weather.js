my.position = { lat: "56.2", lon: "15.541667" };
my.vader = {};

my.WeatherForecast = function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (p) {
            var coords = p.coords;
            my.position.lat = coords.latitude;
            my.position.lon = coords.longitude;
        });
    }
    var url = "/Weather/GetForecast/" + my.position.lat + ";" + my.position.lon;
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (xhr.status == 200 && xhr.readyState == 4) {
            var vaderData = JSON.parse(xhr.responseText);
            my.vader = vaderData;
            for (var f = 0; f < vaderData.length; f++) {
                var forecast = vaderData[f];
                var timeid = "hour" + (f + 1) + "-time";
                var tempratureid = "hour" + (f + 1) + "-temprature";

                var timespanElement = document.getElementById(timeid);
                var tempraturespanElement = document.getElementById(tempratureid);
                timespanElement.innerText = forecast.Time;
                tempraturespanElement.innerText = forecast.Temprature;
            }
        }
    };
    xhr.open("GET", url, true);
    xhr.send();
};

