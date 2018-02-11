function Weapon(line) {
	this.name;
	this.strikeSpeed;
	this.element;
	this.damage;
	this.line = line;
	this.position;
}

Weapon.prototype.move = function(intervalSpeed) {
	var self = this;
	var fieldWidth = $('#field').width();
	var width = fieldWidth - this.element.width();

	var refreshIntervalId = setInterval(function() {
		self.position += self.strikeSpeed;
		self.element.css('left', self.position);

		if (self.position >= width || gameover) { 
			clearInterval(refreshIntervalId);
			self.die();
		}
		
		for (var i = 0; i < zombies[self.line].length; i++) {
			if (zombies[self.line][i].position + self.position - fieldWidth > -50 && zombies[self.line][i].isAlive) {
				clearInterval(refreshIntervalId);
				self.die();
				zombies[self.line][i].explode(self.damage);
			}
		}
		
	}, intervalSpeed);
}

Weapon.prototype.die = function(line) {
	$(this.element, '#field').remove();
};

