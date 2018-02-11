function Strong() {
	Zombie.apply(this, arguments);
	this.name = "strong";
	this.speed = 2;
}

Strong.prototype = Object.create(Zombie.prototype);
