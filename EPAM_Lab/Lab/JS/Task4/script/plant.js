function Plant(line) {
	this.element = $("<div class='plant'></div>");
	this.strikeGenerationSpeed;
	this.name;
	this.weapons = [];
	this.line = line;
}

Plant.prototype.generate = function(line) {
	this.element.addClass(this.name);
	this.element.css('top', line);
	$(".field-line:nth-child("+line+")").append(this.element);
};
