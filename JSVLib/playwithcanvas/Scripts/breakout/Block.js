// Block.js

var BlockConfig = {
    Padding: 5,
    Size: { w: 30, h: 16 },
    Type: [
        { color: "#00ff00", score: 10 },
        { color: "#ff0000", score: 20 },
        { color: "#00ffff", score: 30 },
        { color: "#ffff00", score: 40 },
        { color: "#ffffff", score: 50 },
        { color: "#aaaaaa", score: 60 },
    ]
};

function Block(context, pos, type) {
    var self = this;
    var size = BlockConfig.Size;
    var myPos = pos;
    var color = BlockConfig.Type[type].color;
    var blockContext = context;
    var hitsLeft = 1;
    var ID = pos.x.toString() + pos.y.toString();
 
    self.ID = function() {
        return ID;

    };
    
    self.active = function() {
        return hitsLeft > 0;
    };

    self.draw = function () {
        if (!self.active()) {
            return;
        }
        blockContext.fillStyle = color;
        blockContext.fillRect(myPos.x, myPos.y, size.w, size.h);

    };

    self.hitTest = function(object) {
        var otherObjectPos = object.getPos();
        var otherObjectSize = object.getSize();
        if ((otherObjectPos.x + otherObjectSize) >= myPos.x && otherObjectPos.x <= (myPos.x + size.w)) {
          if ((otherObjectPos.y + otherObjectSize) >= myPos.y && otherObjectPos.y <= (myPos.y + size.h)) {
              console.log("BLOCK " + ID + " was hit!");
              hitsLeft = hitsLeft - 1;
              object.onHit();
              return true;
          }
        }
        return false;
    };
    
    self.onHit = function () {
        console.log("BLOCK " + ID + " was hit!");
        hitsLeft = hitsLeft - 1;
    };

    self.getPos = function () {
        return myPos;
    };

    self.getSize = function () {
        return {width: size.w, height: size.h};
    };

    self.getObjectType = function () {
        return "BLOCK";
    };

}
