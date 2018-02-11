window.onload = function() {
	for(var i = 0; i < data.length; i++){
		var item = data[i];
		 if (data[i] === null)
		 	item = "не указано";
		 else if (data[i] === undefined)
		 	item = "не определено";
		document.write("<p>data[" + i + "]=" + item + "</p>");
	}
}