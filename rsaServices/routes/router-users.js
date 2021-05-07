const express = require('express');
const router = express.Router()
const Joi = require('joi')
const bcrypt = require('bcryptjs')
const passport = require('passport')
const User = require('../models/model-users')
 
//validation schema
 
var sessao

// router.route('*')
//	.get((req, res, next) => {
//		sess = req.session
//		sess = req.session

/* 		if (sess.estaAutenticado) {
			res.redirect('/assets')
		} */
//	}) 

const userSchema = Joi.object().keys({
	email: Joi.string().email().required(),
	username: Joi.string().required(),
	password: Joi.string().regex(/^[a-zA-Z0-9]{6,30}$/).required(),
	confirmationPassword: Joi.any().valid(Joi.ref('password')).required()
})


router.route('/login')
	.get((req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER USERS - GET - route login')
		console.log('     Sessao: ' + req.session.id)
		if ( typeof sessao.estaAutenticado == 'undefined') {
			sessao.estaAutenticado = false
			sessao.save()
		}
		if (req.session.estaAutenticado) {
			console.log('     Step: Usuario autenticado, enviando a pagina ROOT')
			res.redirect('/')
			return
		}
		console.log('     Step: Usuario nao autenticado, renderizando a pagina de login')
		res.render('vw-login')
	})
	.post(async (req, res) => {
		console.log(' ==> ROUTER USERS - POST - route login')
		console.log('     Sessao: ' + req.session.id)
		try 
		{
			const result = Joi.validate(req.body, userSchema)
			//const user =  User.getUser(result.value.email)
			const user = await User.getUser(result.value.email)
			console.log('Voltei')
			var valid
			if (user !== null) {
				console.log('     Step: Usuario encontrado na base, verificando a senha')
				console.log('     Step: Usuario: ' + user.password)
				valid = await bcrypt.compare(result.value.password, user.password)
			}
			else {
				console.log('     Step: Usuario nao encontrado na base')
				valid = false
			}

			if (!valid) {
				console.log('     Step: Usuario nao valido, enviando a pagina de login')
				req.flash('error', 'User or password invalid')
				res.redirect('/')
				return
			}
			console.log('     Step: Usuario autenticado, enviando para a pagina ROOT')
			sessao.estaAutenticado = true
			sessao.save()
			res.redirect('/')
		}
		catch(error) {

		}
	})

router.route('/register')
	.get((req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER USERS - GET - route register')
		console.log('     Sessao: ' + req.session.id)
		if ( typeof sessao.estaAutenticado == 'undefined') {
			sessao.estaAutenticado = false
			sessao.save()
		}
		console.log('     Step: Renderizando para pagina para registro de usuario')
		res.redirect('/')
	})
	.post(async (req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER USERS - POST - route register')
		console.log('     Sessao: ' + req.session.id)
		if ( typeof sessao.estaAutenticado == 'undefined') {
			sessao.estaAutenticado = false
			sessao.save()
		}
		try {
			console.log('     Step: Validando os dados recebidos')
			const result = Joi.validate(req.body, userSchema)
			if (result.error) {
				console.log('     Step: Dados de registros invalidos, continuando com registro')
				console.log('     ' + result.error)
				req.flash('error', 'Data entered is not valid. Please try again.')
				res.locals.success_messages = "Erro cadastrando o usuario, favor repetir"
				res.redirect('/')
				return
			}
			console.log('     Step: Verficando se o usuario ja existe')
			const user = User.findOne({ 'email': result.value.email })
			if (user) {
				console.log('     Step: Usuario ja cadastrado, enviando para o login')
				req.flash('error', 'Email is already in use.')
				res.redirect('/')
				return
			}

			const hash = await User.hashPassword(result.value.password)
			delete result.value.confirmationPassword
			result.value.password = hash
			const newUser = await new User(result.value)
			await newUser.save()
			console.log('     Step: Usuario cadastrado, enviando para o login')
			req.flash('success', 'Registration successfully, go ahead and login.')
			res.redirect('/')

		}
		catch(error) {

		}
	})

 router.route('/profiles')
	.get((req, res) => {
		sessao = req.session
		console.log(' ==> ROUTER USERS - GET - route profiles')
		console.log('     Sessao: ' + req.session.id)
		if ( typeof sessao.estaAutenticado == 'undefined') {
			sessao.estaAutenticado = false
			sessao.save()
		}
		if (!sessao.estaAutenticado) {
			var menus = [
				{ id: 'mnu0', label:'Login', target:'#'},
				{ id: 'mnu99', label:'Sobre', target:'#'}
			]
			console.log('     Step: Usuario nao autenticado, enviando para os dados para montagemd menu')
			console.log(menus)
			res.status(200).json(menus)
			return
		}
		var menus = [
			{ id: 'mnu1', label:'Ativos', target:'/assets'},
			{ id: 'mnu2', label:'Dashboard', target:'#'},
			{ id: 'mnu99', label:'Sobre', target:'#'}
		]
		console.log('     Step: Usuario autenticado, enviando os dados para montagem do menu')
		console.log(menus)
		res.status(200).json(menus)
	})




router.route('/dashboard')
	.get((req, res, next) => {
		sess = req.session
		if (!sess.estaAutenticado) {
			res.redirect('/')
			return
		}
		console.log(' ==> Render do HTML Dashboard')	  
		res.render('vw-dashboard')
	})
	.post(async (req, res, next) => {
		next()
	})
  





  module.exports = router