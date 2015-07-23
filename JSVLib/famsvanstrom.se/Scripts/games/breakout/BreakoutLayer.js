/// <reference path="../../jsvlib.js/mathex.js" />
/// <reference path="Ball.js" />

jsvgame.BreakoutLayer = function(params) {
    var maxy = params.maxy;
    var maxx = params.maxx;
    console.log("maxx = %s, maxy = %s", maxx, maxy);
    var context = params.context;
    var balls = [];

    balls.push(new Ball({maxx: params.maxx, maxy: params.maxy, context: context}));
    
    return {
        updateLayer: function () {
            for (var i = 0; i < balls.length; i++) {
                balls[i].move();
            }
        },
        repaintLayer: function () {
            for (var i = 0; i < balls.length; i++) {
                balls[i].draw();
            }
        }
    };

}
