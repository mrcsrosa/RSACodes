var profiles;

function startnav() {
	var http = new XMLHttpRequest();
	if (typeof(profile) === 'string') {
		http.open("GET", '/users/profiles='+profile, true);
	}
	else {
		http.open("GET", '/users/profiles', true);
	}
	http.setRequestHeader("Content-type", "application/json");
	http.onreadystatechange = function() {
		if (http.readyState == 4 && http.status == 200) {
			console.log(http.response)
			buildAccess(JSON.parse(http.response))
		}	
		else {
		}
	}
	http.send(null);
}
function buildAccess(parProfiles){
	var mnu = document.getElementById('myMenu')
	console.log(parProfiles)
	console.log('el: '  + mnu);
	var x
	for(i=0; i< parProfiles.length; i++) {
		console.log('Menu: ' + parProfiles[i].label)
		if (parProfiles[i].id === 'mnu0') {
			x = createLink(parProfiles[i].id, parProfiles[i].label, parProfiles[i].target);
		}
		else {
			x = createLink(parProfiles[i].id, parProfiles[i].label, parProfiles[i].target);
		}
		mnu.appendChild(x);
	}
	justShow1();
	justShow2();
}
function createButton(parID, parLink, parTarget) {
	var btn=document.createElement('button')
	
	btn.innerText = parLink;
	if ( parID === 'mnu0') {
		btn.setAttribute('onclick', "document.getElementById('id01').style.display='block'");
	}
	else {
		btn.setAttribute('window.location.href', parTarget) 
	}
	btn.setAttribute('style', 'width:auto;')
	return btn
}
function createLink(parID, parLink, parTarget) {
	var anc = document.createElement('a')
	anc.setAttribute('href', parTarget);
	if (parID === 'mnu1') {
		anc.setAttribute('class', 'active');
		anc.setAttribute('onclick', 'showInOut();')
	}
	if ( parID === 'mnu0') {
		anc.setAttribute('onclick', "document.getElementById('id01').style.display='block';showInOut();");
	}
	anc.setAttribute('id', parID);
	anc.innerText = parLink;
	return anc;
}
function justShow1() {
	document.getElementById('id01').style.display='none'
}
function justShow2() {
	document.getElementById('id02').style.display='none'
}