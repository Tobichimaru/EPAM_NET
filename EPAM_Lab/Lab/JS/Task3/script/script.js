function random(min, max) {
	return Math.floor((Math.random() * max) + min);
}

function changeState(val1, val2, val3) {
	changeButtonState("#generate", val1);
    changeButtonState("#set-color", val2);
    changeButtonState("#reset", val3);
}

function changeButtonState(elem, active) {
    if (!active) {
        $(elem).addClass("disabled");
        return;
    }
    $(elem).removeClass("disabled");
}

function generate() {
	if ($(this).hasClass("disabled")) {
		return;
	}
   	reset();
	var n = random(50, 100);
	for (var i = 0; i < n; i++) {
		var $item = $("<div class='block'></div>").text(random(1, 100));
		$('#main-container').append($item); 
	}
	changeState(false, true, true);
}

function setColor() {
	if ($(this).hasClass("disabled")) {
		return;
	}
	$(".block").each(function() {
		var $item = $(this);
		var number = parseInt($item.text());
		if (number > 75) 
			$item.css("background-color", "#f44336");
		else if (number > 50)
			$item.css("background-color", "#ff9800");
		else if (number > 25)
			$item.css("background-color", "#4caf50");
		
	});
	changeState(false, false, true);
}

function reset() {
	if ($(this).hasClass("disabled")) {
		return;
	}
	$('#main-container').empty();
	changeState(true, false, false);
}

$(function() {
	changeState(true, false, false);
	$('#generate').click(generate);
	$('#set-color').click(setColor);
	$('#reset').click(reset);
});

