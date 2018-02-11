var sum = [0, 0, 0];

for (var i = 0; i < 5; i++) {
	if (typeof items[i].getCount1 === 'function') 
		sum[0] += items[i].getCount1();
	if (typeof items[i].getCount2 === 'function') 
		sum[1] += items[i].getCount2();
	if (typeof items[i].getCount3 === 'function') 
		sum[2] += items[i].getCount3();
}

for (var i = 0; i < 3; i++) {
	document.write("<h2>count" + (i + 1) + "=" + sum[i] + "</h2>");
}