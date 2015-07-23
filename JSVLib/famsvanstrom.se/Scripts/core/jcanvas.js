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
    phId = phId.charAt(0) == "#" ? phId.substring(1) : phId;
    var cw = width;
    var ch = height;

    var props = new Reflector(htmlAttributes).getProperties();
    var canvas = document.createElement("canvas");
    canvas.width = cw;
    canvas.height = ch;
//    var canvasTag = '<canvas width="' + cw + '" height="' + ch + '" ';
    for (var i = 0; i < props.length; i++) {
        //canvasTag = canvasTag + props[i] + '="' + htmlAttributes[props[i]] + '" ';
        var attr = document.createAttribute(props[i]);
        attr.value = htmlAttributes[props[i]];
        canvas.setAttributeNode(attr);
    }
    //canvasTag = canveasTag + "></canvas>";

    //var canvasElem = $(canvasTag);
    //var context = canvasElem.get(0).getContext('2d');
    //canvasElem.appendTo(phId);
    document.getElementById(phId).appendChild(canvas);
    var context = canvas.getContext("2d");
    
    return {
        context: context,
        width: cw,
        height: ch,
        element: canvas
    };
    //self.context = function () {
    //    return context;
    //};
}
