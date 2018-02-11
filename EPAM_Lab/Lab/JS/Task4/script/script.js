function random(min, max) {
	return Math.floor((Math.random() * max) + min);
}

function initialize() {
	for (var i = 0; i < NUMBER_OF_LINES; i++)
		occupiedLines[i] = false;

	zombies = new Array();
	for (var i = 0; i < NUMBER_OF_LINES; i++){
	    zombies[i] = new Array();
	}
}

$(document).ready(function() {
	initialize();

	$("#btnGenerate").click(function() {
		var zombieType = random(1, 2);
	    var zombie;
	    if (zombieType == 1) {
	    	zombie = new Strong();
	    } else {
	    	zombie = new Michael();
	    }
	    var line = random(1, NUMBER_OF_LINES);
	    zombie.generate(line);
	    zombie.walk(STEP_SPEED);

	    zombies[line-1].push(zombie);
	});

	$("#btnGeneratePlant").click(function() {
		numberOfplants++;
		if (numberOfplants <= NUMBER_OF_LINES) {
			var line = random(1, NUMBER_OF_LINES);
			while (occupiedLines[line-1]) {
				line = random(1, NUMBER_OF_LINES);
			}
			occupiedLines[line-1] = true;
			var plant = new Green(line);
			plant.generate(line);
		    plant.strike(STEP_SPEED);
		    plants.push(plant);
		}
	});

	$("#btnSlowUp").click(function() {
		for (var i = 0; i < NUMBER_OF_LINES; i++){
			for (var j = 0; j < zombies[i].length; j++) {
				zombies[i][j].slowUp();
			}
		}
	});

	$("#btnGrowOld").click(function() {
		var seconds = 10;
		for (var i = 0; i < NUMBER_OF_LINES; i++){
			for (var j = 0; j < zombies[i].length; j++) {
				zombies[i][j].growOld(1, seconds);
			}
		}
	});

	$("#btnExplode").click(function() {
		for (var i = 0; i < NUMBER_OF_LINES; i++){
			for (var j = 0; j < zombies[i].length; j++) {
				zombies[i][j].explode(EXPLODE_RATE);
			}
		}
	});
});