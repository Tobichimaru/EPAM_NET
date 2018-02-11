function Green(line) {
	Plant.apply(this, arguments);
	this.name = "green";
	this.strikeGenerationSpeed = 3000;
	this.line = line;
}

Green.prototype = Object.create(Plant.prototype);

Green.prototype.strike = function(stepSpeed) { 
	var self = this;
	var refreshIntervalId = setInterval(function() {
		if (gameover) { 
			clearInterval(refreshIntervalId);
		}
		var weapon = new Peanut(self.line-1);
		$(".field-line:nth-child("+self.line+")").append(weapon.element);
		self.weapons.push(weapon);		
		weapon.move(stepSpeed);
	}, self.strikeGenerationSpeed);
}