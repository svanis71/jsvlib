// Bat.js

function Bat(context) {
    var width = 80;
    var height = 16;
    var batContext = context;
    var size = { width: 80, height: 16 };
    var pos = {
        x: (MyConstants.canvasWidth / 2) - (width / 2),
        y: MyConstants.canvasHeight - height - 6
    };
    var self = this;
    var speed = 5;
    var prevMousePos = { x: 0, y: 0 };
    var batImg = new Image();

    // Create bat
    var tmpCanvasElem = $('<canvas id="tc1" class="invisible" width="' + size.width + '" height="' + size.height + '"></canvas>');
    var ctx = tmpCanvasElem.get(0).getContext("2d");
    tmpCanvasElem.appendTo("#hiddenCanvasPH");
    var tmpImg = new Image();
    tmpImg.onload = function() {
        ctx.drawImage(tmpImg, 0, 0);
        var pixels = ctx.getImageData(0, 0, size.width, size.height);
        for (var i = 0; i < pixels.data.length; i += 4) {
            if (pixels.data[i] == 255 && pixels.data[i + 2] == 255 && pixels.data[i + 1] == 0) {
                pixels.data[i+3] = 0;
            }
        }
        ctx.clearRect(0, 0, size.width, size.height);
        ctx.putImageData(pixels, 0, 0);
        batImg.src = tmpCanvasElem.get(0).toDataURL();
        $("#hiddenCanvasPH canvas").remove();
    };
    tmpImg.src = "data:image/png;base64,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";
    
    self.move = function (direction) {
        if (direction == Directions.Left) {
            if (pos.x >= 2) {
                pos.x -= speed;
            }
        }
        if (direction == Directions.Right) {
            if (pos.x <= MyConstants.canvasWidth - size.width - 2) {
                pos.x += speed;
            }
        }
        //console.log("BAT pos.x = " + pos.x+ " pos.y = " + pos.y + " width = " + size.width + " height = " + size.height);
        
    };

    self.hitTest = function(object) {

    };
    
    self.onHit = function () {
    };

    self.getPos = function() {
        return pos;
    };

    self.getSize = function() {
        return size;
    };

    self.getObjectType = function() {
        return "BAT";
    };
    
    self.draw = function () {
        //var color = batContext.createLinearGradient(pos.x, pos.y, pos.x, pos.y + height);
        //color.addColorStop(0, "rgba(30, 200, 100, 0.5)");
        //color.addColorStop(0.5, "rgba(30, 100, 100, 0.5)");
        //color.addColorStop(1, "rgba(30, 100, 20, 0.5)");
        //batContext.beginPath();
        //batContext.rect(pos.x, pos.y, width, height);
        //batContext.fillStyle = color;
        //batContext.fill();
        if (latestMouseEvent != null) {
            var posText = "cx: " + latestMouseEvent.clientX + ", cy: " + latestMouseEvent.clientY +
                "px: " + latestMouseEvent.pageX + " py: " + latestMouseEvent.pageY +
                "ox: " + latestMouseEvent.offsetX + "oy: " + latestMouseEvent.offsetY;
            batContext.font = "8pt Arial";
            var wid = batContext.measureText(posText).width;
            batContext.fillText(posText, MyConstants.canvasWidth - wid - 20, 10);
        }
        batContext.drawImage(batImg, pos.x, pos.y);
    };

    self.keyboardHandler = function (e) {
        //console.debug("bat.keyboardHandler");
        switch (e.keyCode) {
            case 37: // Left
                self.move(Directions.Left);
                break;
            case 39: // Right
                self.move(Directions.Right);
                break;
        }
    };

    var latestMouseEvent = null;
    self.mouseHandler = function (e) {
        latestMouseEvent = e;
         pos.x = e.offsetX;
    };
};
