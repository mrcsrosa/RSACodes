var assets;
var isInsert = false;
function handleClick(assets) {
	var http = new XMLHttpRequest();
	if (typeof(assets) === 'string') {
		http.open("GET", '/assets/entrada?asset='+assets, true);
	}
	else {
		http.open("GET", '/assets/entrada', true);
	}

	http.setRequestHeader("Content-type", "application/json");

	http.onreadystatechange = function() {
		if (http.readyState == 4 && http.status == 200) {
			fillAssetDetail(JSON.parse(http.response));
			setSubmitState(true)
			setStateAsset(true)
		}
		else {
			console.log('readyState=' + http.readyState + ', status: ' + http.status);
		}
	}
	
	http.send(null);
}
function pageUpdate(frm) {
	//var btn = document.getElementById('btUpdate')
	//alert('Algume vai chamar')
	frm.setAttribute('method', 'POST')
	frm.setAttribute('action', '/assets/entrada')
	console.log('Atribuido o valor da aciton ' + frm.action);
	//alert(btn.type)
	//frm.submit()
}
function start() {
	var http = new XMLHttpRequest();
	http.open("GET", '/assets/list', true);
	http.setRequestHeader("Content-type", "application/json");
	http.onreadystatechange = function() {
		console.log('onreadystatechange');
		if (http.readyState == 4 && http.status == 200) {
			assets = JSON.parse(http.response);
			initialize();
		}
		else {
		}
	}
	http.send(null);
}
function fillAssetDetail(asset) {
	document.getElementById("ativo").value = asset.ativo
	document.getElementById("tipoativo").value = asset.tipoativo
	document.getElementById("propriedade").value = asset.tipopropriedade
	document.getElementById("descricao").value = asset.descricao
	document.getElementById("serie").value = asset.serie
	document.getElementById("fabricacao").value = asset.fabricadoem
	document.getElementById("alocado").value = asset.localalocado
}
function setDate2Show(pardate) {
/* 	var mydate = new Date(pardate);
	var tmzOff = mydate.getTimezoneOffset();

	var formatDate = mydate.getUTCFullYear() + '-'+ ('00' + mydate.getMonth()).slice(-2) + '-' + ('00' + mydate.getDate()).slice(-2);	
	alert('Entreguei : ' + pardate + '\r\nParse date: ' + mydate + '\r\nAno       : ' + mydate.getUTCFullYear() + '\r\nMes       : ' + (mydate.getMonth()+1) + '\r\nAno       : ' + mydate.getDate() + '\r\nDevolvi   : ' + formatDate + '\r\nTMZ offset: ' + mydate.getTimezoneOffset())
	
	return formatDate; */
}
function setDate2Save(pardate) {
/* 	var mydate = new Date(Date.parse(pardate));
	var formatDate = mydate.toISOString();
	return formatDate; */
}
function createAnchorAsset(parAsset, pos) {
	var tagInput = document.createElement('input');
	tagInput.setAttribute("type", "radio");
	tagInput.setAttribute("name", "assets");
	tagInput.setAttribute("value", parAsset);
	tagInput.setAttribute("onclick", "return handleClick(value)");
	if (pos === 0) {
		tagInput.setAttribute("checked", true);
	}

	return tagInput
}
function createAnchorLabel(parAsset) {
	var tagLabel = document.createElement('label');
	tagLabel.innerHTML = '&nbsp;&nbsp;'+ parAsset;
  
	return tagLabel
}
function initialize() {
	var anchor1 = document.querySelector('#assetsChoice');
	var i
	var result
	var result2
	console.log (assets[0].ativo)
	if ( assets.length > 0 ) {
		for(i=0; i < assets.length; i++) {
			result = createAnchorAsset(assets[i].ativo, i)
			anchor1.appendChild(result);
			result2 = createAnchorLabel(assets[i].ativo + ' - ' + assets[i].descricao);
			anchor1.appendChild(result2);
			anchor1.appendChild(document.createElement('br'))
		}
		handleClick(assets[0].ativo);
		setStateAsset(true);
		setSubmitState(true)
		document.getElementById('btUpdate').value = 'SAVE';
	}
}
function setStateAsset(parState) {
	document.getElementById("ativo").disabled = parState
	document.getElementById("tipoativo").disabled = parState
	document.getElementById("propriedade").disabled = parState
	document.getElementById("descricao").disabled = parState
	document.getElementById("serie").disabled = parState
	document.getElementById("fabricacao").disabled = parState
	document.getElementById("alocado").disabled = parState
}
function setSubmitState(parState) {
	var btUpdate = document.getElementById('btUpdate')
	//btUpdate.disabled = parState;
}
function setNewState(parState) {
	var btUpdate = document.getElementById('btNew')
	btUpdate.disabled = parState;
}
function setPencilState(parState) {
	var btUpdate = document.getElementById('pencil-asset-edit')
	btUpdate.disabled = parState;
}
function setInsertState(parState) {
	var btNew = document.getElementById('btNew')
	btNew.disabled = parState;
	setStateAsset(false);
}
function prepareInsert() {
	var frm = document.getElementById('myframe').elements;
	
	for (i =0; i < frm.length;i++) {
		console.log('Attribute: ' + frm[i].name)
		if (frm[i].name.startsWith("fld")) {
			frm[i].value = "";
		}
	}	
	setInsertState(true);
	setSubmitState(false);
	isInsert = true;
}
function prepareUpdate(par) {
	if (isInsert) {
		par.value = 'SAVE';
		//document.getElementById('myframe').disabled = false;
		isInsert = false;
	}
	else {
		par.value = 'UPDATE';
	}
	//setStateAsset(true);
	setSubmitState(true);
	setNewState(false);
	return;
}


//start();
