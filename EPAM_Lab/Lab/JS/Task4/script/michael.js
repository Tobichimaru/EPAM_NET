function Michael() {
	Zombie.apply(this, arguments);
	this.speed = 3;
	this.health = 70;
	this.currentHealth = this.health;
	this.name = "michael";
}

Michael.prototype = Object.create(Zombie.prototype);