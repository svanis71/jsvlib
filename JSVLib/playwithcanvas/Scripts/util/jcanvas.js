/// <reference path="reflector.js" />

// Shim for requestAnimationFrame
window.requestAnimationFrame = (function () {
    return window.requestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
})();


function JCanvas(phId, width, height, htmlAttributes) {
    var self = this;
    phId = phId.charAt(0) == "#" ? phId : ("#" + phId);
    var cw = width;
    var ch = height;

    var props = new Reflector(htmlAttributes).getProperties();
    var canvasTag = '<canvas width="' + cw + '" height="' + ch + '" ';
    for (var i = 0; i < props.length; i++) {
        canvasTag = canvasTag + props[i] + '="' + htmlAttributes[props[i]] + '" ';
    }
    canvasTag = canvasTag + "></canvas>";

    var canvasElem = $(canvasTag);
    var context = canvasElem.get(0).getContext('2d');
    canvasElem.appendTo(phId);

    self.context = function () {
        return context;
    };
}
