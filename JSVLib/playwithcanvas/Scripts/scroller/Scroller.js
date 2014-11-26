/// <reference path="../util/stringex.js" />
/// <reference path="../util/jcanvas.js" />

function Scroller() {
    var self = this;
    var cw = ($("#canvasPH").width() - 20);
    var ch = 70;
    var keepGoing = true;

    var canvas = new JCanvas("canvasPH", cw, ch, { id: "c1" });
    var context = canvas.context();
    
    var text = "Den här texten ska komma scrollande från höger......";
    var x = cw;
    var textWid = context.measureText(text).width;
    var tmp = text;
    context.font = "28pt Comic Sans MS";
    while (textWid < cw) {
        tmp = tmp + text;
        textWid = context.measureText(tmp).width;
    }
    text = tmp;
    var charWid = context.measureText(text.charAt(0)).width;
    var scrollTo = -charWid;
    $("#stop").on("click", function () { keepGoing = false; });

    self.stop = function () { keepGoing = false; };

    var color = context.createLinearGradient(0, 0, 0, ch);
    color.addColorStop(0, "rgba(100, 200, 100, 1)");
    color.addColorStop(0.5, "rgba(200, 150, 50, 1)");
    color.addColorStop(1, "rgba(255, 100, 255, 1)");

    self.draw = function () {
        context.clearRect(0, 0, cw, ch);
        context.strokeStyle = color;
        context.strokeText(text, x, ch / 2);
        if (x > scrollTo) {
            x -= 1;
        }
        else {
            text = text.rotate();
            charWid = context.measureText(text.charAt(0)).width;
            scrollTo = -charWid;
            x = 0;
        }
        if (keepGoing == true) {
            window.requestAnimationFrame(self.draw);
        }

    };

}
