// start.js
$(function () {
    console.log("onReady");
    var mgr = new MyGameManager();
    window.requestAnimationFrame(mgr.splash);
    console.log("onReady finished");
    $(document).on("keydown", function (e) {
        mgr.keyboardHandler(e);
    });
    $(document).on("click", function (e) {
        mgr.mouseHandler(e);
    });

});
