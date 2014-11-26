// game.js
function MyGameManager() {
    console.log("MyGameManager: constructor");
    console.log(MyConstants);
    var interval = 0;
    var state = GameStates.Splash;
    var self = this;

    var context = null; // The canvas
    /* Constructor code */
    var canvasElem = $('<canvas id="c1" class="gameCanvas" width="' + MyConstants.canvasWidth + '" height="' + MyConstants.canvasHeight + '"></canvas>');
    context = canvasElem.get(0).getContext('2d');
    canvasElem.appendTo("#canvasPH");
    
    // Screen items
    var bat = new Bat(context);
    var ball = new Ball(context);
    var blocks = [];

    console.log("canvas setup finished");

    // Event handlers for my custom events
    $(document).on("showMenu", function () {
        console.log("EVENT: showMenu catched");
        self.drawMenuScreen();
        self.setState(GameStates.Menu);
    });

    $(document).on("gameOver", function () {
        console.log("EVENT: gameOver catched");
        self.setState(GameStates.HighScore);
        self.drawGameOver();
    });

    $(document).on("start", function () {
        console.log("EVENT: start catched");
        self.setState(GameStates.Running);
        window.requestAnimationFrame(self.run);
    });

    $(document).on("pause", function () {
        console.log("EVENT: pause catched");
        self.setState(GameStates.Paused);
        self.pause();
    });

    $("#c1").on("newGame", function() {
        var margin = 40;
        var blockCOls = (MyConstants.canvasWidth - (margin * 2)) / (BlockConfig.Size.w + BlockConfig.Padding);
        var blockRows = 8;

        blocks = [];
        // Creates an array with all the blocks
        var brickY = margin;
        for (var y = 0; y < blockRows; y++) {
            var brickX = margin;
            for (var x = 0; x < blockCOls; x++) {
                blocks.push(new Block(context, { x: brickX, y: brickY }));
                brickX += BlockConfig.Size.w + BlockConfig.Padding;
            }
            brickY += BlockConfig.Size.h + BlockConfig.Padding;
        }
        $(document).trigger("start");
    });
    
    $("#c1").on("mousemove", function (e) {
        self.mouseHandler(e);
    });

    /* Public methods */
    self.clearScreen = function () {
        context.clearRect(0, 0, MyConstants.canvasWidth, MyConstants.canvasWidth);
    };

    self.run = function () {
        if (self.getState() == GameStates.Running) {
            self.clearScreen();
            self.update();
            self.repaint();
            window.requestAnimationFrame(self.run);
        }
    };

    self.pause = function () {
        setState(self.getState() == GameStates.Paused ? GameStates.Running : GameStates.Paused);
        clearInterval(interval);
    };

    self.update = function () {
        ball.move();
        ball.testCollision(bat);
        blocks.forEach(function (b) {
            if (b.active()) {   
                if (b.hitTest(ball)) {
                    
                }
            }
        });
    };

    self.repaint = function () {
        blocks.forEach(function (b) {
            b.draw();
        });
        bat.draw();
        ball.draw();
    };

    self.drawGameOver = function () {
        var menuString = "Game Over";
        self.clearScreen();
        context.font = '14pt Comic Sans MS';
        context.fillStyle = "#4444ff";
        var metrics2 = context.measureText(menuString);
        var x = (MyConstants.canvasWidth / 2) - (metrics2.width / 2);
        var y = (MyConstants.canvasHeight / 2);
        context.fillText(menuString, x, y);
    };

    self.drawMenuScreen = function () {
        var menuString = "S = Start, P = Pause";
        self.clearScreen();
        context.font = '14pt Comic Sans MS';
        context.fillStyle = "#4444ff";
        var metrics2 = context.measureText(menuString);
        var x = (MyConstants.canvasWidth / 2) - (metrics2.width / 2);
        var y = (MyConstants.canvasHeight / 2);
        context.fillText(menuString, x, y);

    };

    self.setState = function (newState) {
        state = newState;
    };

    self.getState = function () {
        return state;
    };

    self.keyboardHandler = function (e) {
        var currState = self.getState();
        var key = e.keyCode;
        if (currState == GameStates.Splash || currState == GameStates.HighScore) {
            console.log("Triggar showMenu!");
            $(document).trigger("showMenu");
        }
        else if (currState == GameStates.Menu || currState == GameStates.Paused) {
            //var key = e.charCode > 90 ? e.charCode - 32 : e.charCode;
            if (key == 83) {// S 
                console.log("Triggar start");
                $("#c1").trigger("newGame");
            }
        } else if (currState == GameStates.Running) {
            if (key == 80) {// P 
                console.log("Triggar pause!");
                $(document).trigger("pause");
            }
            bat.keyboardHandler(e);
        }

    };

    self.mouseHandler = function (e) {
        var currState = self.getState();
        if (e.type != "mousemove") {
            console.log(e);
        }
        if (e.type == "click" && currState == GameStates.Splash) {
            console.log("Triggar showMenu via mouse!");
            $(document).trigger("showMenu");
        }

        if (e.type == "mousemove" && currState == GameStates.Running) {
            
            bat.mouseHandler(e);
        }
    };

    var splashInfo = {
        welcomeText: "Welcome",
        metrics: null,
        alpha: 0.0,
        blue: 55,
        fontSize: 20
    };

    self.splash = function () {
        context.font = '60pt Comic Sans MS';
        context.lineWidth = 4;
        splashInfo.metrics = context.measureText(splashInfo.welcomeText);
        var fullX = (MyConstants.canvasWidth / 2) - (splashInfo.metrics.width / 2);
        var fullY = (MyConstants.canvasHeight / 2);
        if (splashInfo.alpha <= 1.0) {
            context.font = splashInfo.fontSize + 'pt Comic Sans MS';
            var innerMetrics = context.measureText(splashInfo.welcomeText);
            var xi = (MyConstants.canvasWidth / 2) - (innerMetrics.width / 2);
            context.clearRect(fullX - 10, fullY - 60, fullX + splashInfo.metrics.width + 40, fullY);
            context.strokeStyle = 'rgba(68, 68, ' + splashInfo.blue + ', ' + splashInfo.alpha + ')';
            context.strokeText(splashInfo.welcomeText, xi, fullY);
            splashInfo.alpha += 0.05;
            splashInfo.blue += 10;
            splashInfo.fontSize += 2;
            window.requestAnimationFrame(self.splash);
        }
        else {
            var hitAnyKeyText = "Hit any key";
            context.font = '14pt Comic Sans MS';
            context.fillStyle = "#4444ff";
            var metrics2 = context.measureText(hitAnyKeyText);
            var xh = (MyConstants.canvasWidth / 2) - (metrics2.width / 2);
            context.fillText(hitAnyKeyText, xh, fullY + 40);
        }
    };

    /* End public mmethods */
    console.log("MyGameManager: constructor done");

}
