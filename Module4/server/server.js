var express = require('express');
var http = require('http');
var socketIo = require('socket.io');
var os = require('os');
var mysql = require('mysql');
var death = require('death'); 
 
var connection = mysql.createConnection({
	host: '173.194.229.132',
	user: 'tgrigorov',
	password: '',
	database: 'Spawnage'
});

var app = express();
var server = http.createServer(app);
var io = socketIo.listen(server);

var expressConfig = require('./express-config');
expressConfig.configure(app, express, os, server);

var socket = require('./socket-config');
connection.connect();
socket.listen(io, connection);

death(function(signal, err) {
  connection.end(); 
  process.exit();
});