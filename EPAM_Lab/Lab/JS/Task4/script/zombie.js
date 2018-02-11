function Zombie() {
	this.name;
	this.speed;
	this.minSpeed = 1;
	this.position = 0;
	this.health = 50;
	this.currentHealth = this.health;
	this.isAlive = true;

	this.element = $("<div class='zombie'></div>");
	
	this.healthWrapper = $("<div class='health-bar-wrapper'></div>");
	this.healthBarText =  $("<p>" + this.currentHealth + '/' + this.health + "</p>");
	this.currentHealthBar = $("<div class='health-bar-current'></div>");

	this.healthWrapper.append("<div class='health-bar'></div>");
	this.healthWrapper.append(this.currentHealthBar);
	this.healthWrapper.append(this.healthBarText);

	this.element.append(this.healthWrapper);
}

Zombie.prototype.walk = function(stepSpeed) {
	var self = this;
	var width = $('#field').width() - $('.zombie').width();
	var gameOverText = $(".game-over");

	var refreshIntervalId = setInterval(function() {
		self.position += self.speed;
		if (!self.isAlive) {
			clearInterval(refreshIntervalId);
		} else if (self.position >= width || gameover) {
			clearInterval(refreshIntervalId);
			if (!gameover) {
				gameover = true;
				gameOverText.text('Game Over!');
				gameOverText.show();
			}
			self.die();
		}
		self.element.css('right', self.position);
	}, stepSpeed);	
};

Zombie.prototype.generate = function(line) {
	this.element.css('top', line);
	this.element.append("<div class=" + this.name + "></div>");
	
	$(".field-line:nth-child("+line+")").append(this.element);
};

Zombie.prototype.die = function() {
	$(this.element, '#field').remove();
	this.isAlive = false;
	var index = zombies.indexOf(this.element);
	if (index > -1)
		zombies.splite(index, 1);
};

Zombie.prototype.slowUp = function() {
	this.speed = this.minSpeed;
};

Zombie.prototype.growOld = function(power, time) {
	var self = this;
	var currentTime = 0;

	var refreshIntervalId = setInterval(function() {
		self.explode(1);
		currentTime++;
		if (!self.isAlive || currentTime >= time) {
			clearInterval(refreshIntervalId);
		}
	}, 1000);
};

Zombie.prototype.explode = function(power) {
	this.currentHealth -= power;
	this.currentHealthBar.width((this.healthWrapper.width()/this.health)*this.currentHealth);
	this.healthBarText.text(this.currentHealth + '/' + this.health);

	if (this.currentHealth <= 0 || !this.isAlive) {
		this.die();
	}
}
