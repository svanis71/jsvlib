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


function JCanvas(container, width, height, htmlAttributes) {
    var self = this;
    var cw = width;
    var ch = height;

    var props = new Reflector(htmlAttributes).getProperties();
    var canvas = document.createElement("canvas");
    canvas.width = cw;
    canvas.height = ch;
    for (var i = 0; i < props.length; i++) {
        var attr = document.createAttribute(props[i]);
        attr.value = htmlAttributes[props[i]];
        canvas.setAttributeNode(attr);
    }
    container.appendChild(canvas);
    var context = canvas.getContext("2d");
    
    return {
        context: context,
        width: cw,
        height: ch,
        element: canvas
    };
}
