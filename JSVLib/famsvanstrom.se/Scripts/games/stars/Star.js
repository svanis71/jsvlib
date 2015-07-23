function Star(params) {
    var random = function (pmin, pmax) {
        var max = pmax - pmin;
        var num = Math.floor(Math.random() * max) + pmin;
        return num;
    };
        
    var reset = function() {
        pt.x = random(maxx / 2 - 30, maxx / 2 + 30);
        pt.y = random(maxy / 2 - 30, maxy / 2 + 30);
        xdir = pt.x < (maxx / 2) ? -1 : 1;
        ydir = pt.y < (maxy / 2) ? -1 : 1;
        speed.x = Math.random() * 2 * xdir;
        speed.y = Math.random() * 1.5 * ydir;
        speed2 = { x: speed.x, y: speed.y };
        pt.radius = 1;
        pt.color = colors[4];
    };

    var self = this;
    var maxy = params.maxy;
    var maxx = params.maxx;
    var origo = { x: maxx / 2, y: maxy / 2 };
    var diagonalLength = Math.sqrt(maxx * maxx + maxy * maxy) / 2;
    var colors = ["#fff", "#bbb", "#999", "#666", "#444"];
    var color = colors[4];
    var pt = { x: random(0, maxx), y: random(0, maxy), radius: 1, color: colors[4] };
    xdir = pt.x < (maxx / 2) ? -1 : 1;
    ydir = pt.y < (maxy / 2) ? -1 : 1;
    var speed = { x: Math.random() * 2 * xdir, y: Math.random() * 1.5 * ydir };
    var speed2 = { x: speed.x, y: speed.y };
    var radius = 1;

    return {
        move: function () {
            pt.x += speed.x;
            pt.y += speed.y;
            
            if ((pt.x > (maxx - radius) || pt.x < radius) ||
                (pt.y > (maxy - radius) || pt.y < radius)) {
                reset();
            }
            var x = Math.abs(origo.x - pt.x);
            var y = Math.abs(origo.y - pt.y);
            var dist = Math.sqrt(x * x + y * y);
            if (dist < diagonalLength * 0.8) {
                pt.color = colors[0];
                speed.x = speed2.x * 2.5;
                speed.y = speed2.y * 2.2;
            }
            if (dist < diagonalLength * 0.6) {
                pt.color = colors[2];
                speed.x = speed2.x * 2;
                speed.y = speed2.y * 1.8;
            }
            if (dist < diagonalLength * 0.4) {
                pt.color = colors[3];
                speed.x = speed2.x * 1.5;
                speed.y = speed2.y * 1.2;
            }

        },
        pos: pt,
        radius: radius,
        color: color
    };
}