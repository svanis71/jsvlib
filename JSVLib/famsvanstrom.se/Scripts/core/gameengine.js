/// <reference path="jcanvas.js" />
/// <reference path="jquery-2.0.3.min.js" />
/// <reference path="modernizr-2.5.3.js" />
/// <reference path="breakoutlayer.js" />
/// <reference path="StarfieldLayer.js" />


function GameEngine() {
	var self = this;
    var canvasPh = document.getElementById("canvasPH");
    var cw = window.innerWidth;
    var ch = window.innerHeight;
    var canvas = new JCanvas("canvasPH", cw, ch, { id: "c1", class: "gameCanvas" });
    var context = canvas.context;

    var _isRunning = false;

    // Screen layers
    var layers = [];

    var _start = function () {
        // Health check
        for (var index = 0; index < layers.length; index++) {
            if (!layers[index].updateLayer || !layers[index].repaintLayer) {
                throw new Error("interface error in layer " + index);
            }
        }
        console.log("Nu köör vi!");
        console.log("Wow!");
        _isRunning = true;
        window.requestAnimationFrame(self.run);
    };

    var _pause = function () {
        _isRunning = false;
    };

    var _run = function () {
        if (_isRunning) {
            // Clear screen
            context.fillStyle = "#000";
            context.clearRect(0, 0, cw, ch);

            // Update and repaint all layers
            for (var index = 0; index < layers.length; index++) {
                if (!layers[index].updateLayer || !layers[index].repaintLayer) {
                    throw new Error("interface error in layer " + index);
                }
                layers[index].updateLayer();
                layers[index].repaintLayer();
            }
            window.requestAnimationFrame(self.run);
        }
    };

    return {
        init: function () {
            self = this;
            // First layer is background
            var layer = new StarfieldLayer(canvas, { numOfStars: 1 });
            layers.push(layer);

            // Second layer is the game
        },
        start: _start,
        pause: _pause,
        run: _run
    };
};
