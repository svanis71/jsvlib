function StopWatch(){

var startTime = null;
var stopTime = null;
var running = false;

    this.start = function() {

        if (running == true)
            return;
        else if (startTime != null)
            stopTime = null;

        running = true;
        startTime = getTime();
    };

    this.stop = function() {

        if (running == false)
            return this;

        stopTime = getTime();
        running = false;

        return this;
    };

    this.duration = function () {
        if (startTime == null) {
            return 'Undefined';
        }
        if (stopTime == null) {
            stopTime = getTime();
        }
        else
            return (stopTime - startTime) / 1000;
    };

    this.isRunning = function() { return running; };

    this.getTime = function() {
        var day = new Date();
        return day.getTime();
    };


}
