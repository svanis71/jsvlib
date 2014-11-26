// Ball.js
function Ball(canvasContext) {
    var self = this;
    var size = 16;
    var pos = { x: 20, y: MyConstants.canvasHeight - 50 };
    var ySpeed = -3;
    var xSpeed = 3;
    var ballContext = canvasContext;
    var gameOver = false;
    var ballImg = new Image();
    ballImg.src = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACYElEQVQ4T22TXUgUURTH/7PuTEuh29YqLkGJKD4sKkuFIVv7kAZLRkj1EGQvgWuW4ke1lsW+9OAQgRpl6FMvy1IPviwUtVSLYggpGhmrfRBS9IU7rT6ssLvd5t47OzNaF2bO4c78f/M/554R8J8VuniNrGfXAUF9KBAWRdGKm4O36M6GtWEj1N7PhepyFNnhKLQDFoJ0Jo1vyR86UB4e0nV6Ejx3idAvuXdXocHjg6vECRSoX7f+YVFJK4i9nsBM4i1zJQ9xCLtdb+sjmWwWfk8DfNX1qkAVaUIWTfnC50VEnkSRyWUgDw4LDBBs7SV1FfvQfOAos8wuJqJiNd8EjM9O4/FEnAOCgV4iFlhxpbkThVu3cU9UQO2zS8t1Jxwqj41BWU1BCLb1kPLSPWj1t/DuUkDexWaACRZ9+QKTM7Mq4HwP2VtZg1OHjmkAWoIGoQJWjuZEL41g+s0cxp/GVEB7N3GXVaHlyAnDAT17s4s8xGL0JDY1hdjkKxVwoZvQ2vvPdvKhMZdBS6B75p5QiLo/GnmIT8tfIAxcDRFlLYUm72F4a/frk6c7YOVopWiNXf7+FfceRCBKVj4HwY4uYpO2IHDyNFzOEm5fG2GWU6EWlbXfGA0/gpJahXz7Dp+D8N37ZH4xAZskwX/Qh7raGtNp0JOhtoGF90uIPo8zsavUia7LIQ5gkJERMp9IsNxhL4K7sgLFO3fAKlrwc2UF7z58xK9kkoHLy3Yh0NFnjHIeQuNA6AZRUimjmaypvLk2mwRvvQeNTWf+/ZnMEJo/Gw8zUDaXQ7FzOxqPGyLzu38BhXwCL1RRvtwAAAAASUVORK5CYII=";
    
    self.move = function () {
        if (gameOver) { return; }
        pos.x += xSpeed;
        if (pos.x > MyConstants.canvasWidth) {
            pos.x = MyConstants.canvasWidth;
            xSpeed *= -1;
        }
        else if (pos.x < 0) {
            pos.x = 0;
            xSpeed *= -1;
        }
        pos.y += ySpeed;
        if (pos.y < 0) {
            pos.y = 0;
            ySpeed *= -1;
        }
        if (pos.y > MyConstants.canvasHeight) {
            $(document).trigger("gameOver");
            gameOver = true;
        }
    };
    
    self.draw = function () {
        ballContext.drawImage(ballImg, pos.x, pos.y, size, size);
    };

    self.getPos = function () {
        return pos;
    };

    self.getSize = function () {
        return size;
    };

    self.getObjectType = function () {
        return "BALL";
    };

    self.onHit = function () {
        ySpeed *= -1;
    };

    self.testCollision = function(object) {
        var otherObjectPos = object.getPos();
        var otherObjectSize = object.getSize();
        
        if ((pos.x + size) > otherObjectPos.x && pos.x < (otherObjectPos.x + otherObjectSize.width)) {
            if ((pos.y + size) >= otherObjectPos.y) {
                console.log("BALL hits " + object.getObjectType());
                object.onHit();
                ySpeed *= -1;
                if (((pos.x + size) < (otherObjectPos.x + 3)) ||
                (pos.x >= (otherObjectPos.x + otherObjectSize.width - 3))) {
                    xSpeed *= -1;
                }
            }
        }
        //var dx = Math.abs(pos.x - otherObjectPos.x);
        //var dy = Math.abs(pos.y - otherObjectPos.y);
        //var rad = size / 2;
        //return (dx * dx + dy * dy) < (rad * rad);

        
    };
};
