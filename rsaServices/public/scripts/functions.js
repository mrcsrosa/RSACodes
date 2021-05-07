function handleClick(assets) {
	document.getElementById('myframe').src = '/assets/entrada?asset='+assets.value;
	document.getElementById('myframe').getElementById('refresh').click();
}
