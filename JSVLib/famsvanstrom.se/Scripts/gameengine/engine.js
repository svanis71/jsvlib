/// <reference path="../jsvlib.js/jsv.canvas.js" />

jsvgame = {};
jsvgame.sprites = [];
jsvgame.images = [];
jsvgame.GameResources = {
    atlas: null,
    atlasJSON: null
};

var ImageLoader = (function () {
    
    return {
        load: function (imgUrl, jsonUrl) {
            var atlas = new Image();
            atlas.onload = function() {
                var xhr = new XMLHttpRequest();
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        
                    }
                };
                xhr.open("GET", jsonUrl, true);
                xhr.send();
            };
            atlas.src = imgUrl;
        }
    };
})();

jsvgame.GameEngine = function(settings) {
    var self = this;
    var engineSettings = settings || {};
    var canvasPhClass = engineSettings.canvasPhClass || "game-canvas-container";
    var query = (canvasPhClass.charAt(0) === '.' ? '' : '.') + canvasPhClass;
    var canvasContainer = document.querySelector(query); //document.getElementById(canvasPhClass);

    var cw = engineSettings.canvasWidth || (window.innerWidth * 0.95 - canvasContainer.offsetTop);
    var ch = engineSettings.canvasHeight || (window.innerHeight * 0.95 - canvasContainer.offsetTop);
    var canvas = new JCanvas(canvasContainer, cw, ch, { "id": "c1", "class": "gameCanvas" });
    var context = canvas.context;
    var isRunning = false;

    // Screen layers
    var layers = [];

    // Game properties
    var bgUrl = settings.background || "background.png";
    var background = null;
    
    self._addLayer = function(layer) {
        layers.push(layer);
    };
    
    self._start = function () {
        if (layers.length == 0) // Nothing to paint
            return;
        
        self = this;
        // Health check
        for (var index = 0; index < layers.length; index++) {
            if (!layers[index].updateLayer || !layers[index].repaintLayer) {
                throw new Error("interface error in layer " + index);
            }
        }
        console.log("Nu köör vi!");
        isRunning = true;
        window.requestAnimationFrame(self.run);
    };

    self._pause = function () {
        isRunning = false;
    };

    self._run = function () {
        if (isRunning) {
            // Clear screen
            if (background !== null) {
                context.drawImage(background, 0, 0, cw, ch);
            } else {
                context.fillStyle = "black";
                context.fillRect(0, 0, cw, ch);
            }
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

    self._loadImages = function(images) {
        //var loader = new ImageLoader();
        //for (var i = 0; i < images.length; i++) {
        //    loader.load(images[i].image, images[i].json);
        //}
    };
    
    return {
        init: function () {
            background = new Image();
            background.onload = function() {
                context.drawImage(background, 0, 0, cw, ch);
            };
            background.src = bgUrl;
        },
        loadImages: self._loadImages,
        addLayer: self._addLayer,
        start: self._start,
        pause: self._pause,
        run: self._run
    };
};
