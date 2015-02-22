/// <reference path="../../../../Scripts/jquery-1.8.2.min.js" />
/// <reference path="../../../../Scripts/modernizr-2.6.2.js" />

var MyConstants = {
    canvasWidth: 1024,
    canvasHeight: 30    
};

function Menuline() {
    this.canvas = null;
    this.baseY = 10;
    this.endX = 1024;
    var elem = $("<canvas id='hc' width='" + MyConstants.canvasWidth + "' height='" + MyConstants.canvasHeight + "' />");
    if (!elem.get(0).getContext)
        return false; /* TODO skapa fallback */
    this.canvas = elem.get(0).getContext('2d');
    elem.appendTo("#canvasPH");
    this.baseLine();
    this.hookHover();
    return this;
}

Menuline.prototype.hookHover = function hookHover() {
    var self = this;
    $("#nav li").hover(function() {
        var path = [];
        var wid = $(this).width();
        var left = $(this).position().left;
        var nextX = left + wid / 2;
        path.push({ x: nextX, y: self.baseY });
        nextX += 4;
        path.push({ x: nextX, y: self.baseY - 6 });
        nextX += 4;
        path.push({ x: nextX, y: self.baseY });
        nextX = 1024;
        path.push({ x: nextX, y: self.baseY });
        self.drawLine(path);
    })
        .mouseleave(function() {
            self.baseLine();
        });

};

Menuline.prototype.drawLine = function (pts) {
    this.clearScreen();
    this.canvas.beginPath();
    this.canvas.moveTo(0, 10);
    for (var i = 0; i < pts.length; i++) {
        this.canvas.lineTo(pts[i].x, pts[i].y);
    }
    /*this.context.lineTo(1024, 10);*/
    this.canvas.lineWidth = 2;
    this.canvas.stroke();
};

Menuline.prototype.clearScreen = function() {
    this.canvas.clearRect(0, 0, MyConstants.canvasWidth, MyConstants.canvasHeight);
};

Menuline.prototype.baseLine = function() {
    var path = [{ x: MyConstants.canvasWidth, y: this.baseY }];
    console.log("Menuline.baseLine");
    this.drawLine(path);
};

//var menuLine = {
//    context: null,
//    baseY: 10,
//    endX: 1024,
//    canvasWidth: 1024
//    canvasHeight: 30,

//    create: function () {
//        var elem = $("<canvas id='hc' width='" + this.canvasWidth + "' height='" + this.canvasHeight + "' />");
//        if (!elem.get(0).getContext)
//            return false; /* TODO skapa fallback */
//        this.context = elem.get(0).getContext('2d');
//        elem.appendTo("#canvasPH");
//        this.baseLine();
//    },

//    hookHover: function () {
//        $("#nav li").hover(function () {
//            var path = [];
//            var wid = $(this).width();
//            var left = $(this).position().left;
//            var nextX = left + wid / 2;
//            path.push({ x: nextX, y: menuLine.baseY });
//            nextX += 4;
//            path.push({ x: nextX, y: menuLine.baseY - 6 });
//            nextX += 4;
//            path.push({ x: nextX, y: menuLine.baseY });
//            nextX = 1024;
//            path.push({ x: nextX, y: menuLine.baseY });
//            menuLine.drawLine(path);
//        })
//                .mouseleave(function () {
//                    menuLine.baseLine();
//                });

//    },

//    baseLine: function () {
//        var path = [{ x: this.canvasWidth, y: this.baseY}];
//        this.drawLine(path);
//    },

//    drawLine: function (pts) {
//        this._clearScreen();
//        this.context.beginPath();
//        this.context.moveTo(0, 10);
//        for (var i = 0; i < pts.length; i++) {
//            this.context.lineTo(pts[i].x, pts[i].y);
//        }
//        /*this.context.lineTo(1024, 10);*/
//        this.context.lineWidth = 2;
//        this.context.stroke();
//    },

//    _clearScreen: function () {
//        this.context.clearRect(0, 0, this.canvasWidth, this.canvasHeight);
//    }
//};

