jsvgame.Splash = function(engine) {

};

// Load game when page is ready
document.addEventListener("DOMContentLoaded", function (event) {
    var engine = new jsvgame.GameEngine({ background: '/Content/img/games/breakout/background.png'});
    engine.init();
    engine.loadImages([{
        image: '/Content/img/games/breakout/breakout.png',
        json: '/Scripts/games/breakout/breakout.json'
    }]);
});