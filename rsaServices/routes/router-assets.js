const express = require('express');
const router = express.Router()
const Joi = require('joi')
const bcrypt = require('bcryptjs')
//const Data = require('../models/data')

const Asset = require('../models/model-assets')

var sessao

//validation schema
 
//const userSchema = Joi.object().keys({
//  email: Joi.string().email().required(),
//  username: Joi.string().required(),
//  password: Joi.string().regex(/^[a-zA-Z0-9]{6,30}$/).required(),
//  confirmationPassword: Joi.any().valid(Joi.ref('password')).required()
//})
 
router.route('/')
	.get(async (req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER ASSETS - GET - route ROOT')
		console.log('     Sessao: ' + req.session.id)
		if (!sessao.estaAutenticado) {
			console.log('     Step: Usuario nao autenticado, enviando a pagina /users/login')
			res.redirect('/')
			return
		}
		console.log('     Step: Usuario autenticado, renderizando a pagina asset-main')
		res.render('assets/vw-asset-main')
	})
	
router.route('/entrada')
	.get(async (req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER ASSETS - GET - route entrada')
		console.log('     Sessao: ' + req.session.id)
		if (!sessao.estaAutenticado) {
			console.log('     Step: Usuario nao autenticado, redirecionado para a /users/login')
			res.redirect('/')
			return
		}
		if (req.query.asset) {
			console.log('     Step: pesquisando o ativo ' + req.query.asset )
			const valueAsset = await Asset.getAsset(req.query.asset, true)
			res.status(200).json(valueAsset)
		} 
		else {
			console.log('     Step: reload page assets/asset-input')
			res.render('assets/vw-asset-input', {layout:false})	  
		}
	})
	.post(async (req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER ASSETS - POST - route ROOT')
		console.log('     Sessao: ' + req.session.id)
		if (!sessao.estaAutenticado) {
			console.log('     Step: Usuario nao autenticado, enviando a pagina /users/login')
			res.redirect('/')
			return
		}
		try 
		{		
			console.log('     Step: processando dados para DB')
			console.log(req.body);
			console.log('que valor é esse: ' + req.body.fldativo);
			if (req.body.btUpdate === 'UPDATE') {
				console.log('     Step: processando UPDATE no ROOT ?')
				const ret = await Asset.updateAsset(req.body)
			}
			else if (req.body.btUpdate === 'SAVE') {
				console.log('     Step: processando INSERT no ROOT?')
				const ret =  Asset.insertAsset(req.body)
				if (ret === 0) {
					res.locals.returnedMessage = "Ativo nao registrado";
				}
				else {
					res.locals.returnedMessage = "Ativo registrado";
				}
				console.log('     Step: retorno do INSERT : ' + ret)				
			}
			res.redirect('/assets')
		}
		catch(error) {

		}
	})

router.route('/list')
	.get(async (req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER ASSETS - GET - route list')
		console.log('     Sessao: ' + req.session.id)
		if (!sessao.estaAutenticado) {
			console.log('     Step: Usuario nao autenticado, redirecionado para a /users/login')
			res.redirect('/')
			return
		}
		console.log('     Step: retorna lista de ativos')
		res.status(200).json(await Asset.getAssets())
	})


module.exports = router