/// <reference path="../../jsvlib.js/mathex.js" />
/// <reference path="Star.js" />
function StarsLayer(params) {
    var maxy = params.maxy;
    var maxx = params.maxx;
    console.log("maxx = %s, maxy = %s", maxx, maxy);
    var context = params.context;
    var numOfStars = 1000;
    var stars = [];
    for (var i = 0; i < numOfStars; i++) {
        stars.push(new Star({ maxx: params.maxx, maxy: params.maxy }));
    }
    
    return {
        updateLayer: function () {
            /*_y += _ys;
            _x += _xs;
            if (_x > maxx || _x < 0 ||
                _y > maxy || _y < 0) {
                _x = _startx;
                _y = _starty;
            }*/
            for (var idx = 0; idx < stars.length; idx++) {
                stars[idx].move();
            }
        },
        repaintLayer: function () {
            for (var idx = 0; idx < stars.length; idx++) {
                context.fillStyle = stars[idx].pos.color;
                context.fillRect(stars[idx].pos.x, stars[idx].pos.y, stars[idx].pos.radius, stars[idx].pos.radius);
            }
            //context.fillStyle = colors[speed % 5];
            //context.fillRect(_x, _y, speed % 5, speed % 5);
        }
    };

}
