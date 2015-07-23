function Ball(params) {
    var self = this;
    var maxx = params.maxx - 16;
    var maxy = params.maxy - 16;
    var context = params.context;
    console.log("maxx = %s, maxy = %s", maxx, maxy);

    var pos = { x: maxx / 2, y: maxy / 2 };
    var speed = { x: -2, y: 1 };
    var urls = ["ball1.png", "ball2.png"];
    var ballImgs = [];
    var fpsCount = 0;
    var loadCount = 0;
    var curFrame = 0;
    
    for (var i = 0; i < urls.length; i++) {
        ballImgs.push(new Image());
        var href = "/Content/img/games/breakout/" + urls[i];
        ballImgs[i].src = href;
        ballImgs[i].onload = function() {
            loadCount += 1;
        };
        console.log("Loading " + href);
    }
    
    
    return {
        draw: function () {
            var imgToDraw = ballImgs[curFrame];
            if (loadCount == ballImgs.length) {
                fpsCount += 1;
                if (fpsCount > 15) {
                    fpsCount = 0;
                //    ballImgs.shift();
                    //    ballImgs.push(imgToDraw);
                    curFrame = (curFrame + 1) % ballImgs.length;
                }
                context.drawImage(imgToDraw, pos.x, pos.y);
            }
        },
        move: function() {
            pos.x += speed.x;
            pos.y += speed.y;
            if (pos.x < 0) {
                pos.x = 0;
                speed.x *= -1;
            }
            if (pos.x > maxx) {
                pos.x = maxx;
                speed.x *= -1;
            }
            if (pos.y < 0) {
                pos.y = 0;
                speed.y *= -1;
            }
            if (pos.y > maxy) {
                pos.y = maxy;
                speed.y *= -1;
            }
        },
        testCollision: function(obj) {

        }
    };
}