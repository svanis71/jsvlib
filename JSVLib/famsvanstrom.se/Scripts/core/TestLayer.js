﻿/// <reference path="star.js" />

function Point(x, y)
{
	var _x = x;
	var _y =y;
	var _clear = false;
	
	return {
		x: _x,
		y: _y,
		clear: function() { _clear = true; },
		remove: _clear
	};
}

function TestLayer(canvas, params) {
	var myCanvas = canvas;
	var context = myCanvas.context;

	stars = [];
	cols = ["#fff", "#bbb", "#888", "#555"]
	
	var rnd = function(max) {
		return Math.random() * max;
	}

	var _updateLayer = function() {
		var newX = rnd(window.innerWidth);
		var newY =  rnd(window.innerHeight);
		
		if(stars.length > 200) {
			stars = stars.splice(1, 199);
			stars[0].clear();
		}
		stars.push(new Point(newX, newY));
	};

	var _repaintLayer = function () {
		for (var idx = 0; idx < stars.length; idx++) {
			var mod = idx % 4;
			var star = stars[idx];
			if(star.remove) {
				context.fillStyle = "#000#";	
			}
			else {
				context.fillStyle = cols[idx % 4];
			}
			context.fillRect(star.x, star.y, 2 + mod, 2 + mod);

		}
	};

	return {
		updateLayer: _updateLayer,
		repaintLayer: _repaintLayer
	};
};