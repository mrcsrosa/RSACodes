const express = require('express');
const expressHandlebars = require('express-handlebars');
const session = require('express-session');
const bodyParser = require('body-parser');
const compression = require('compression');
const morgan = require('morgan');
const path = require('path');
//const cookieParser = require('cookie-parser');
const flash = require('connect-flash');
const mongoose = require('mongoose')
const {MongoClient} = require('mongodb')
const app = express()

app.use(compression())
app.use(morgan('dev'))

//require('./config/passport')
//mongoose.Promise = global.Promise
//mongoose.connect('mongodb://localhost:27017/site-auth')
const client = new MongoClient('mongodb://192.168.1.15:27017/site-auth')
// 1

// 2
 
// 3
app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: false }))
//app.use(cookieParser())
app.use(express.static(path.join(__dirname, 'public')))
app.use(session({
  cookie: { maxAge: 600000},
  secret: 's3cr3t@',
  secure: false,
  saveUninitialized: false,
  resave: false
}));

// 2

app.set('views', path.join(__dirname, 'views'))
app.engine('hbs', 
			expressHandlebars({ 
				extname: 'hbs', 
				defaultLayout: 'layout-main'
			})
		)
app.set('view engine', 'hbs')

// 4
app.use(flash())
app.use((req, res, next) => {
  res.locals.success_mesages = req.flash('success')
  res.locals.error_messages = req.flash('error')
  res.locals.session = req.session;
  res.locals.returnedMessage = "";
  next()
})
 
// 5
const userControler = require('./routes/router-index');
const userAssets = require('./routes/router-assets');
app.use('/', userControler)
app.use('/assets', userAssets)
app.use('/users',  require('./routes/router-users'))
app.use('/dyna',  require('./routes/dyna'))


// 6
// catch 404 and forward to error handler
app.use((req, res, next) => {
  res.render('vw-notFound')
});
// 7
app.listen(5000, () => console.log('Server started listening on port 5000!'))

