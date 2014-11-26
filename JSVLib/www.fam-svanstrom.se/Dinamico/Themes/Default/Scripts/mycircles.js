MyConstants = function () {
    return {
        canvasWidth: 480,
        canvasHeight: 320,
        fps: 30
    };
} ();

function Circle(obj) {
    var xDirection = 1;
    var yDirection = 1;
    var xPos = 300;
    var yPos = 40;
    var radius = 40;
    var xSpeed = 2;
    var ySpeed = 2;
    var radiusGrowth = 1;
    var isHit = false;
    var color = null;

    /* Constructor code */
    if (obj.radius != undefined)
        radius = obj.radius;
    if (obj.xSpeed != undefined)
        xSpeed = obj.xSpeed;
    if (obj.xSpeed != undefined)
        xSpeed = obj.xSpeed;

    xPos = MathEx.random(radius + xSpeed, MyConstants.canvasWidth - radius - xSpeed);
    yPos = MathEx.random(radius + ySpeed, MyConstants.canvasHeight - radius - ySpeed);
    console.log("Skapat cirkel (" + xPos + ", " + yPos + ") med storlek " + radius + " och fart (" + xSpeed + ", " + ySpeed + ")");
    /*********************/

    this.draw = function (context) {
        if (color == null && !isHit) {
            color = context.createLinearGradient(xPos, yPos, xPos, yPos + radius * 2);
            color.addColorStop(0, "rgba(30, 200, 100, 0.5)");
            color.addColorStop(0.5, "rgba(30, 100, 100, 0.5)");
            color.addColorStop(1, "rgba(30, 100, 20, 0.5)");
        }
        else if (color == null) {
            color = context.createLinearGradient(xPos, yPos, xPos, yPos + radius * 2);
            color.addColorStop(0, "rgba(100, 0, 0, 0.5)");
            color.addColorStop(0.5, "rgba(130, 50, 34, 0.5)");
            color.addColorStop(1, "rgba(255, 0, 0, 0.5)");
        }
        context.fillStyle = color;
        context.beginPath();
        context.arc(xPos, yPos, radius, 0, Math.PI * 2, true);
        context.fill();

    };

    this.move = function () {
        xPos += (xSpeed * xDirection);
        if ((xPos + radius) >= MyConstants.canvasWidth || xPos <= radius) {
            xDirection *= -1;
        }
        yPos += (ySpeed * yDirection);
        if ((yPos + radius) >= MyConstants.canvasHeight || yPos <= radius)
            yDirection *= -1;
    };

    this.getX = function() {
        return xPos;
    };

    this.getY = function() {
        return yPos;
    };

    this.getRadius = function() {
        return radius;
    };

    this.collisionTest = function (otherCircle) {
        var dx = Math.abs(xPos - otherCircle.getX());
        var dy = Math.abs(yPos - otherCircle.getY());
        var rad = radius + otherCircle.getRadius();
        return (dx * dx + dy * dy) < (rad * rad);
    };

    this.getVelocity = function() {
        return { x: xSpeed, y: ySpeed };
    };

    this.setVelocity = function (speed) {
        xSpeed = speed.x;
        ySpeed = speed.y;
    };

    this.hitTest = function (x, y) {
        console.log("Hit test: " + x, ", " + y);
        var dx = Math.abs(xPos - x);
        var dy = Math.abs(yPos - y);
        var hyp = Math.sqrt(dx * dx + dy * dy);
        isHit = hyp < radius;
        if (isHit) {
            color = null;
            setTimeout(function () {
                isHit = false;
                color = null;
            }, 2000);
        }
        return isHit;
    };

}

function CircleManager(canvasPlaceholderSelector) {
    /* Privates */
    var isRunning = false;
    var interval = 0;
    var circles = [];
    var context = null;

    var update = function () {
        for (var thisCircleIndex = 0; thisCircleIndex < circles.length; thisCircleIndex++) {
            // Först flytt
            circles[thisCircleIndex].move();
            
//            // Sedan testas kollision mot andra cirklar
//            for (var otherCircleIndex = thisCircleIndex + 1; otherCircleIndex < circles.length; otherCircleIndex++) {
//                var isCollision = circles[thisCircleIndex].collisionTest(circles[otherCircleIndex]);
//                if (isCollision) {
//                    console.log("Collision!! between " + thisCircleIndex + " and " + otherCircleIndex);
//                    var ts = circles[thisCircleIndex].getVelocity();
//                    var os = circles[otherCircleIndex].getVelocity();

//                    if (ts.x > os.x) {
//                        ts.x 
//                    }
//                        
//                    if ((os.y < 0 && ts.y < 0) || (os.y > 0 && ts.y > 0)) {
//                        ts.x *= -1;
//                        os.x *= -1;
//                    }
//                    if (os.y > 0 && ts.y < 0) {
//                        os.x *= -1;
//                    }
//                    circles[thisCircleIndex].setVelocity(ts);
//                    circles[otherCircleIndex].setVelocity(os);
//                }
//            }
        }
    };

    var repaint = function () {
        circles.forEach(function (c) {
            c.draw(context);
        });
    };

    var clearScreen = function () {
        context.fillStyle = "#000000";
        context.fillRect(0, 0, MyConstants.canvasWidth, MyConstants.canvasHeight);
    };

    /* Constructor code */
    var canvasElem = $('<canvas id="c1" width="' + MyConstants.canvasWidth + '" height="' + MyConstants.canvasHeight + '"></canvas>');
    context = canvasElem.get(0).getContext('2d');
    canvasElem.appendTo(canvasPlaceholderSelector);
    //    circles.push(new Circle({ xPos: 300, yPos: 40, radius: 20, xSpeed: 2, ySpeed: 2, context: context }));
    //    circles.push(new Circle({ xPos: 200, yPos: 60, radius: 30, xSpeed: 1, ySpeed: 4, context: context }));
    //    circles.push(new Circle({ xPos: 100, yPos: 80, radius: 10, xSpeed: 2, ySpeed: 1, context: context }));
    /********************/

    this.start = function () {
        // Testar musklick i circle
        $("#c1").on("click", function (evt) {
            var testX = (evt.pageX - canvasElem.offset().left);
            var testY = (evt.pageY - canvasElem.offset().top);
            console.log("Mouse click! x: " + evt.pageX + ", y: " + evt.pageY);
            console.log("Converts to x: " + testX + ", y: " + testY);
            circles.forEach(function (c) {
                var hit = c.hitTest(testX, testY);
                if (hit)
                    console.log("HIT!");
            });

        });
        interval = setInterval(function () {
            clearScreen();
            update();
            repaint();
        }, 1000 / MyConstants.fps);
        isRunning = true;
    };

    this.stop = function () {
        clearInterval(interval);
        isRunning = false;
    };

    this.addCircle = function (circle) {
        var newCircle = circle;
        if (newCircle == undefined || newCircle == null) {
            var rad = MathEx.random(10, 40);
            var xs = MathEx.random(1, 4);
            var ys = MathEx.random(1, 3);
            newCircle = new Circle({ radius: rad, xSpeed: xs, ySpeed: ys });
        }
        newCircle.context = context;
        circles.push(newCircle);
    };

    this.isRunning = function () {
        return isRunning;
    };
}

MathEx = function () {
    function _random(min, max) {
        if (min > max)
            throw "min must be less than max";
        return (Math.random() * (max - min)) + min;
    };

    return {
        random: _random
    };
} ();

$(function () {
    var circleMgr = new CircleManager("#circleCanvas");
    circleMgr.addCircle(new Circle({ radius: 40, xSpeed: 3, ySpeed: 2 }));
    //circleMgr.addCircle(null);
    circleMgr.addCircle(new Circle({ radius: 30, xSpeed: 1, ySpeed: 1 }));
    //circleMgr.addCircle();
    circleMgr.start();

    $("#btNewCircle").click(function () {
        circleMgr.stop();
        circleMgr.addCircle(new Circle({ radius: parseInt($("#tRadius").val()), xSpeed: parseInt($("#tXSpeed").val()), ySpeed: parseInt($("#tYSpeed").val()) }));
        circleMgr.start();
    });
    $("#btStartstop").on("click", function () {
        if (circleMgr.isRunning()) {
            circleMgr.stop();
            $(this).text("Start");
        } else {
            circleMgr.start();
            $(this).text("Pause");
        }
    });
});
