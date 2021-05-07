const express = require('express')
const router = express.Router()
const {MongoClient} = require('mongodb')
const client = new MongoClient('mongodb://localhost:27017/site-auth')

var sess

router.get('*', async (req, res) => {
	sess = req.session
	if (!sess.estaAutenticado) {
			res.redirect('/users/login')
			return
	}
	console.log(' ==> Execution of Router index')
	res.render('dyna', {layout:false})
})


router.get('/', async (req, res) => {
	sess = req.session
	if (!sess.estaAutenticado) {
			res.redirect('/users/login')
			return
	}

	console.log(' ==> Execution of Router index')
	res.render('dyna', {layout:false})
})


router.get('/readit', async (req, res) => {
	sess = req.session
	if (!sess.estaAutenticado) {
			res.redirect('/users/login')
			return
	}
	console.log(' ==> Execution of Router index')
	console.log(await getXX())
	res.status(200).jsonp(await getXX())
})
 

 
async function getXX() {
	await client.connect()
	const options = {
      projection: { _id: 0, ativo: 1 },
    };
	cursor = await client.db('site-auth').collection('assets').find({}, options)
	assets = await cursor.toArray()
	return assets
}
 
 
module.exports = router