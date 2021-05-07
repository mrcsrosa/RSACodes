// 1
const mongoose = require('mongoose')
const Schema = mongoose.Schema
const bcrypt = require('bcryptjs')
const mongoClient = require("mongodb").MongoClient;
const url = 'mongodb://192.168.1.15:27017';
mongoClient.connect("mongodb://192.168.1.15:27017", { useUnifiedTopology: true })
				.then(conn => global.conn = conn.db("site-auth"))
				.catch(err => console.log('Nao conectado: ' + err))
 
// 2
const userOldSchema = new Schema({
  email: String,
  username: String,
  password: String
}, {
 
  // 3
  timestamps: {
    createdAt: 'createdAt',
    updatedAt: 'updatedAt'
  }
})
const userSchema = new Schema({
	email: String,
	username: String,
	password: String,
	createdAt: Date,
	updatedAt: Date
}) 
// 4
const User = mongoose.model('user', userOldSchema)
module.exports = User
module.exports.hashPassword = async (password) => {
  try {
    const salt = await bcrypt.genSalt(10)
    return await bcrypt.hash(password, salt)
  } catch(error) {
    throw new Error('Hashing failed', error)
  }
}
module.exports.getUser = async (pEmail) => {
	var client 
	try{
		console.log(' ==> MODEL USERS - getUser')
		console.log('     Step: parametro recebido: ' + pEmail)
		var result = await global.conn.collection('users').findOne({email:pEmail})
		console.log('     Step: parametro recebido: ' + result)
		return result
	} catch(error) {
		throw new Error('Hashing failed', error)	
	}
}

