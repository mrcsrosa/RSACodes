const express = require('express')
const router = express.Router()
const {MongoClient} = require('mongodb')
const client = new MongoClient('mongodb://localhost:27017/site-auth')

var sessao

router.get('/', (req, res) => {
	sessao = req.session
	console.log(' ==> ROUTER MAIN - GET')
	console.log('     Sessao: ' + req.session.id)
	if ( typeof sessao.estaAutenticado == 'undefined') {
		sessao.estaAutenticado = false
		sessao.save()
	}
	if (!sessao.estaAutenticado) {
		console.log('     Step: Usuario nao autenticado, enviando a pagina de login')
		//res.redirect('/')
			console.log('     Step: Validando os dados recebidos')
		//res.status(200)
		//return
	} 
	else {
		console.log('     Step: Usuario autenticado, enviando a pagina de MAIN')
	}
	res.render('vw-index')
})

router.get('/headers', function(req,res){
	res.set('Content-Type','text/plain');
	var s = '';
	for(var name in req.headers) s += name + ': ' + req.headers[name] + '\n';
	res.send(s);
});
 
module.exports = router