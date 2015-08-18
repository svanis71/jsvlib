/// <reference path="../jsvlib.js/jsv.canvas.js" />

jsvgame = {};
jsvgame.sprites = [];
jsvgame.images = [];
jsvgame.Events = {
    OnAtlasReady: "AtlasReady"
};

jsvgame.GameResources = {
    atlas: null,
    atlasJSON: null
};

jsvgame.Sprite = function (pName, x, y, w, h) {
    var name = pName;
    var xPos = x;
    var yPos = y;
    var width = w;
    var height = h;

    return {
        name: name,
        xPos: xPos,
        yPos: yPos,
        width: width,
        height: height
    };
};

jsvgame.getSprite = function(name) {
    for (var i = O; i < jsvgame.sprites.length; i++) {
        
    }
};

jsvgame.GameEventManager = function () {
    return {
        raiseOnAtlasReady: function(numOfSprites) {
            var evt = new CustomEvent(jsvgame.Events.OnAtlasReady, { detail: { numOfSprites: numOfSprites } });
            window.dispatchEvent(evt);
        },
        observeOnAtlasReady: function(observer) {
            window.addEventListener(jsvgame.Events.OnAtlasReady, observer);
        }
    }
};

jsvgame.AtlasLoader = function () {

    var parseSpritesHash = function(spriteData) {
        for (var spriteName in spriteData.frames) {
            if (spriteData.frames.hasOwnProperty(spriteName)) {
                var frame = spriteData.frames[spriteName].frame;
                var sp = new jsvgame.Sprite(spriteName, frame.x, frame.y, frame.w, frame.h);
                jsvgame.sprites.push({key: spriteName, sprite: sp});
            }
        }
    };

    var parseSpritesArray = function(spriteData) {
        for (var i = 0; i < spriteData.frames.length; i++) {
            var frame = spriteData.frames[i];
            var sp = new jsvgame.Sprite(frame.filename, frame.frame.x, frame.frame.y, frame.frame.w, frame.frame.h);
            jsvgame.sprites.push({ key: frame.filename, sprite: sp });
        }
    };

    var _loadAtlas = function (imgUrl, jsonUrl) {
        jsvgame.GameResources.atlas = new Image();
        jsvgame.GameResources.atlas.onload = function () {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {
                        var spriteData = JSON.parse(xhr.responseText);
                        parseSpritesArray(spriteData);
                        jsvgame.GameEventManager().raiseOnAtlasReady(jsvgame.sprites.length);
                    }
                    
                }
            };
            xhr.open("GET", jsonUrl, true);
            xhr.send();
        };
        jsvgame.GameResources.atlas.src = imgUrl;
    }

    return {
        load: _loadAtlas
    };
};

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

    self._loadImages = function (images) {

        var loader = new jsvgame.AtlasLoader();
        for (var i = 0; i < images.length; i++) {
            var imgUrl = images[i].image;
            var json = images[i].json;
            loader.load(imgUrl, json);
        }
    };
    
    return {
        loadImages: self._loadImages,
        init: function () {
            jsvgame.GameEventManager.observeOnAtlasReady(function() {
                // Draw background from atlas
            });
            loadImages();
            //background = new Image();
            //background.onload = function() {
            //    context.drawImage(background, 0, 0, cw, ch);
            //};
            //background.src = bgUrl;
        },
        addLayer: self._addLayer,
        start: self._start,
        pause: self._pause,
        run: self._run
    };
};
