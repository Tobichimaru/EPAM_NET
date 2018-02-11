function DynamicItem(type) {
    this.count = random(1, 10);
    var code = "this.getCount" + type + " = function() { return this.count; }";
	eval(code);
}

var items = [];
for (var i = 0; i < 5; i++) {
	var type = random(1, 3);
	var item = new DynamicItem(type);
	items.push(item);

	var code = "item.getCount" + type +"()";
	document.write("<h3>type=" + type + ", count=" + eval(code) + "</h3>");
}