// 1
const mongoose = require('mongoose')
const mongoClient = require("mongodb").MongoClient;
mongoClient.connect("mongodb://192.168.1.15:27017", { useUnifiedTopology: true })
            .then(conn => global.conn = conn.db("site-auth"))
            .catch(err => console.log('Nao conectado: ' + err))
const Schema = mongoose.Schema
const bcrypt = require('bcryptjs')
 
// 2
const assetSchema = new Schema({
	ativo:           String,
	tipoativo:       String,
	descricao:       String,
	serie:           String,
	tipopropriedade: String,
	fabricadoem:     String,
	localalocado:    String,
	historico:
	[
		{
			alocadoem:   String,
			alocainicio: Date, 
			alocaofim:   Date 
		}
	]
})
 
// 4
const Asset = mongoose.model('asset', assetSchema)
module.exports = Asset

module.exports.getAssets = async () => {
	let assets
	try {
		//await client.connect()
		//cursor = client.db('site-auth').collection('assets').find({})
		cursor = global.conn.collection('assets').find({})
		assets = cursor.toArray()
		return assets
	}
	catch (error) {
		throw new Error('Hashing failed', error)
	}
}

module.exports.getAsset = async (pAsset, bOnlyDisplay) => {
	let strHTML = ""
	
	try {
		console.log("Parametro recebido " + pAsset )
		//await client.connect()
		//asset = await client.db('site-auth').collection('assets').findOne({ativo:pAsset})
		asset = await global.conn.collection('assets').findOne({ativo:pAsset})

        return asset
	}
	catch (error) {
		throw new Error('Hashing failed', error)
	}
}


module.exports.getAssetsCount = async () => {
	try {
		//await client.connect()
		//return await client.db('site-auth').collection('assets').find({}).count()
		return await global.conn.collection('assets').find({}).count()
	} catch(error) {
		throw new Error('Hashing failed', error)
	}
}

module.exports.updateAsset = async (parAtivo) => {
	try {
		//await client.connect()
		console.log('Tipo Assets: ' + typeof(parAtivo))
		console.log(parAtivo)	

		
//		var result = await client.db('site-auth').collection('assets').updateOne({ativo: parAtivo.fldativo}, {$set: {tipoativo:parAtivo.fldtipoativo, descricao:parAtivo.flddescricao, serie:parAtivo.fldserie, tipopropriedade:parAtivo.fldpropriedade, fabricadoem:parAtivo.fldfabricacao, localalocado:parAtivo.fldalocado}})
		var result = await global.conn.collection('assets').updateOne({ativo: parAtivo.fldativo}, {$set: {tipoativo:parAtivo.fldtipoativo, descricao:parAtivo.flddescricao, serie:parAtivo.fldserie, tipopropriedade:parAtivo.fldpropriedade, fabricadoem:parAtivo.fldfabricacao, localalocado:parAtivo.fldalocado}})
		
		console.log(result.result)
		return true
	} catch(error) {
		throw new Error('Hashing failed', error)
	}
}

module.exports.insertAsset = async (parAtivo) => {
	try {
		console.log(' ==> MODEL ASSETS - insertAsset')
		console.log('     Step: Insert ativo na base de dados')
		
		//await client.connect()
				
		//var result = await client.db('site-auth').collection('assets').insertOne({ativo: parAtivo.fldativo, tipoativo:parAtivo.fldtipoativo, descricao:parAtivo.flddescricao, serie:parAtivo.fldserie, tipopropriedade:parAtivo.fldpropriedade, fabricadoem:parAtivo.fldfabricacao, localalocado:parAtivo.fldalocado})
		
		let result = await global.conn.collection('assets').insertOne({ativo: parAtivo.fldativo, tipoativo:parAtivo.fldtipoativo, descricao:parAtivo.flddescricao, serie:parAtivo.fldserie, tipopropriedade:parAtivo.fldpropriedade, fabricadoem:parAtivo.fldfabricacao, localalocado:parAtivo.fldalocado})
		console.log('     Step: Resultado da insercao: ' + result.insertedCount)
		
		console.log('     Step: Insert ativo na base de dados ' + result.insertedCount)
		return result.insertedCount
	} catch(error) {
		return 0
	}
}