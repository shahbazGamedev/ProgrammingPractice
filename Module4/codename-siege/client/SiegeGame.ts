/// <reference path="../lib/definitions/phaser.d.ts"/>
/// <reference path="./states/PreloaderState.ts"/>
/// <reference path="./Player.ts"/>

// evaluated at runtime
declare var io: any;
declare var $: any;

module Siege {
    $(function() {
        if (io) {
            SiegeGame.socket = io.connect();

            $('#loginForm').submit(function(e) {
                e.preventDefault();

                var name = $('#loginForm input[type="text"]').val();
                var password = $('#loginForm input[type="password"]').val();

                SiegeGame.socket.emit('login-request', { name: name, password: password });
            });

            SiegeGame.socket.on('login-failed', function() {
                alert('Wrong credentials or already logged in');
            });

            $('#registerForm').submit(function(e) {
                e.preventDefault();

                var name = $('#registerForm input[type="text"]').val();
                var password = $('#registerForm input:nth-child(3)').val();
                var repeatPassword = $('#registerForm input:nth-child(5)').val();

                if (password != repeatPassword) {
                    $('#registerForm input:nth-child(3)').val('');
                    $('#registerForm input:nth-child(5)').val('');
                    alert('Passwords do not match');
                } else {
                    SiegeGame.socket.emit('register-request', { name: name, password: password });

                    SiegeGame.socket.on('register-response', function(data) {
                        if (data.error) {
                            alert('Registration unsuccessful');
                        } else {
                            $('#registerForm input[type="text"]').val('');
                            $('#registerForm input:nth-child(3)').val('');
                            $('#registerForm input:nth-child(5)').val('');
                            alert('Registration successful. You can now login with your new credentials');
                        }
                    });
                }
            });

            SiegeGame.socket.on('authentication', function(data) {
                $('#formsContainer').fadeOut(function() {
                    $('#formsContainer').remove();

                    SiegeGame.game = new SiegeGame(1024, 576);
                    SiegeGame.player = new Player(data);

                    SiegeGame.socket.emit('authenticated');
                });
            });

            SiegeGame.socket.on('disconnect', function() {
                $('#formsContainer').remove();

                if (SiegeGame.game) {
                    $('#canvasContainer').remove();
                }

                alert('Lost connection to server.');
                throw new Error('Lost connection to server.');
            });
        } else {
            alert('Could not establish connection to server.');
            throw new Error('Could not establish connection to server.');
        }
    });
    
    export class SiegeGame extends Phaser.Game {
        constructor(width: number, height: number) {
            super(width, height, Phaser.AUTO, 'canvasContainer', {
                preload: this.preload,
                create: this.create,
            });
        }

        public static game: SiegeGame;
        public static socket: any;
        public static player: Player;

        public preload(): void {
            // prevents game "pausing"
            SiegeGame.game.stage.disableVisibilityChange = true;
        }

        public create(): void {
            this.state.add("Preloader", PreloaderState, true);
        }
    }
}
