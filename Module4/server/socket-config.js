module.exports = {
    listen: function (io, connection) {
        // main event for client-server interaction
        io.sockets.on('connection', function (socket) {
            var socketIndex = clients.indexOf(socket);

            if (socketIndex == -1) {
                clients.push(socket);
                console.log('New client.. [TOTAL: ' + clients.length + ']');
                socketIndex = clients.indexOf(socket);
            }

            socket.on('login-request', function (data) {
                connection.query('SELECT * FROM USER WHERE NAME=' + connection.escape(data.name) + ' AND PASSWORD=' + connection.escape(data.password), function (error, rows, fields) {
                    var sameClientLogged = false;
                    for (var i = 0; i < clients.length; i++) {
                        if (clients[i].player && clients[i].player.name == rows[0].NAME) {
                            sameClientLogged = true;
                            break;
                        }
                    }

                    if (rows.length == 1 && !error && !sameClientLogged) {
                        var playerData = {
                            id: socketIndex + 1,
                            name: rows[0].NAME,
                            level: rows[0].LEVEL,
                            experience: rows[0].EXPERIENCE,
                            currency: rows[0].CURRENCY,
                            characters: rows[0].CHARACTERS
                        };
                        
                        // set data on the client side
                        socket.emit('authentication', playerData);

                        socket.on('authenticated', function () {
                            console.log('User "' + playerData.name + '" signed in.. [ID: ' + playerData.id + ']');

                            // set data on the server side
                            socket.player = {};
                            socket.player.id = playerData.id;
                            socket.player.name = playerData.name;
                            socket.player.level = playerData.level;
                            socket.player.experience = playerData.experience;
                            socket.player.currency = playerData.currency;
                            socket.player.characters = playerData.characters;
                        });
                    } else {
                        socket.emit('login-failed');
                    }
                });
            });

            socket.on('register-request', function (data) {
                var newUser = {
                    NAME: data.name,
                    PASSWORD: data.password,
                    CHARACTERS: defaultCharacters
                };

                connection.query('INSERT INTO USER SET ?', newUser, function (error, rows, fields) {
                    socket.emit('register-response', { error: error });
                });
            });

            socket.on('searching-game', function (data) {
                console.log('User "' + data.name + '" started game search..');

                if (games.length == 0) {
                    createNewGame(socket);
                } else {
                    var gameFound = searchForGame(socket);

                    if (!gameFound) {
                        createNewGame(socket);
                    }
                }
            });

            socket.on('request-enemy-player', function (data) {
                var enemyPlayerData;

                for (var i = 0; i < games.length; i++) {
                    if (games[i].players[0].player.id == data.id) {
                        enemyPlayerData = getEnemyPlayerData(i, 1);
                        break;
                    } else {
                        enemyPlayerData = getEnemyPlayerData(i, 0);
                        break;
                    }
                }

                socket.emit('response-enemy-player', enemyPlayerData);
            });

            socket.on('grassfield-request-background-cloud', function () {
                for (var i = 0; i < games.length; i++) {
                    if (games[i].players[0].player.id == socket.player.id || games[i].players[1].player.id == socket.player.id) {
                        if (!games[i].mapObjects.backgroundClouds) {
                            games[i].mapObjects.backgroundClouds = {
                                delay: (Math.floor(Math.random() * 15) + 1),
                                cloudKey: 'background-cloud00' + Math.floor(Math.random() * 3),
                                y: Math.floor(Math.random() * 100) + 100
                            };

                            socket.emit('grassfield-response-background-cloud', games[i].mapObjects.backgroundClouds);
                        } else {
                            socket.emit('grassfield-response-background-cloud', games[i].mapObjects.backgroundClouds);

                            delete games[i].mapObjects.backgroundClouds;
                        }

                        break;
                    }
                }
            });

            socket.on('grassfield-request-bird', function () {
                for (var i = 0; i < games.length; i++) {
                    if (games[i].players[0].player.id == socket.player.id || games[i].players[1].player.id == socket.player.id) {
                        if (!games[i].mapObjects.bird) {
                            games[i].mapObjects.bird = {
                                delay: Math.floor(Math.random() * 2) + 1,
                                y: Math.floor(Math.random() * 150) + 100
                            };

                            socket.emit('grassfield-response-bird', games[i].mapObjects.bird);
                        } else {
                            socket.emit('grassfield-response-bird', games[i].mapObjects.bird);

                            delete games[i].mapObjects.bird;
                        }

                        break;
                    }
                }
            });

            socket.on('enemy-character-created', function (data) {
                for (var i = 0; i < clients.length; i++) {
                    if (clients[i].player.id == data.id) {
                        clients[i].emit('get-created-enemy-character', { characterType: data.characterType, level: data.level });
                        break;
                    }
                }
            });

            socket.on('game-over', function () {
                for (var i = 0; i < games.length; i++) {
                    if (games[i].id == socket.player.gameId) {
                        console.log('Game finished.. [ID: ' + games[i].id + ']');

                        var enemyPlayer;
                        if (games[i].players[0].player.id == socket.player.id) {
                            enemyPlayer = games[i].players[1];
                        } else {
                            enemyPlayer = games[i].players[0];
                        }

                        if (enemyPlayer) {
                            enemyPlayer.emit('game-over-response');
                        }

                        games.splice(i, 1);
                        gameIdIncrementor--;

                        break;
                    }
                }
            });

            socket.on('lost-enemy-player', function () {
                console.log('Client kicked.. [ID: ' + socket.player.id + ']');

                socketIndex = clients.indexOf(socket);
                clients.splice(socketIndex, 1);
            });

            socket.on('disconnect', function () {
                if (socket.player) {
                    playerDisconnectLogic(socket);
                } else {
                    console.log('Client disconnected.. [ID: ' + (socketIndex + 1) + ']');
                }

                socketIndex = clients.indexOf(socket);
                clients.splice(socketIndex, 1);
            });
        });
    }
};

var clients = [];
var games = [];
var gameIdIncrementor = 1;
var defaultCharacters = '0, 11, 6, 7';

function createNewGame(socket) {
    socket.player.gamePosition = Math.floor(Math.random() * 2);

    socket.emit('assign-position', {
        position: socket.player.gamePosition
    });

    var players = [];
    players.push(socket);

    games.push({
        id: gameIdIncrementor,
        players: players,
        mapObjects: {}
    });

    console.log('Game created.. [ID: ' + gameIdIncrementor + ']');

    socket.player.gameId = gameIdIncrementor;

    gameIdIncrementor++;
}

function searchForGame(socket) {
    var gameFound = false;

    for (var i = 0; i < games.length; i++) {
        if (games[i].players.length == 1) {
            socket.player.gameId = games[i].id;

            var position = games[i].players[0].player.gamePosition == 0 ? 1 : 0;
            socket.player.gamePosition = position;

            socket.emit('assign-position', {
                position: socket.player.gamePosition
            });

            games[i].players.push(socket);

            console.log('User "' + socket.player.name + '" connected to game [ID: ' + games[i].id + ']');

            games[i].players[0].emit('game-begin');
            games[i].players[1].emit('game-begin');

            gameFound = true;

            break;
        }
    }

    return gameFound;
}

function getEnemyPlayerData(index, arrayIndex) {
    return {
        id: games[index].players[arrayIndex].player.id,
        name: games[index].players[arrayIndex].player.name,
        level: games[index].players[arrayIndex].player.level,
        experience: games[index].players[arrayIndex].player.experience,
        currency: games[index].players[arrayIndex].player.currency,
        characters: games[index].players[arrayIndex].player.characters
    };
};

function playerDisconnectLogic(socket) {
    console.log('User disconnected.. [ID: ' + socket.player.id + ']');

    for (var i = 0; i < games.length; i++) {
        if (games[i].id == socket.player.gameId) {
            console.log('Game destroyed.. [ID: ' + games[i].id + ']');

            var enemyPlayer;
            if (games[i].players[0].player.id == socket.player.id) {
                enemyPlayer = games[i].players[1];
            } else {
                enemyPlayer = games[i].players[0];
            }

            if (enemyPlayer) {
                enemyPlayer.emit('enemy-player-disconnect');
            }

            games.splice(i, 1);
            gameIdIncrementor--;

            break;
        }
    }
}
