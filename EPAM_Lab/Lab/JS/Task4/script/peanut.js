function Peanut(line) {
	this.name = "peanut";
	this.strikeSpeed = 4;
	this.element = $("<div class='weapon " + this.name + "'></div>");
	this.damage = 15;
	this.line = line;
	this.position = 50;
}

Peanut.prototype = Object.create(Weapon.prototype);


