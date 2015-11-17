/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="../maps/GrassField.ts"/>
/// <reference path="../bases/FrozenCave.ts"/>
/// <reference path="../bases/ForestCave.ts"/>
/// <reference path="../Position.ts"/>
/// <reference path="../IngameUserInterface.ts"/>
/// <reference path="../CharacterButton.ts"/>

module Siege {
    export class GameState extends Phaser.State {
        private gameMusic;

        private map: IMap;
        private userInterface: IngameUserInterface;


        public init(): void {
            SiegeGame.socket.emit('request-enemy-player', { id: SiegeGame.player.id });
        }

        public create(): void {
            this.gameMusic =SiegeGame.game.add.audio('game-music',0.5,true);
            this.gameMusic.play();

            var that = this;

            SiegeGame.socket.on('enemy-player-disconnect', function() {
                SiegeGame.socket.emit('lost-enemy-player');

                SiegeGame.game.destroy();
                alert('Lost connection to enemy player.');
                throw new Error('Lost connection to enemy player.');
            });

            SiegeGame.socket.on('response-enemy-player', function(data) {
                that.initialize(data);
            });

            SiegeGame.socket.on('get-created-enemy-character', function(data) {
                Character.createEnemy(data.characterType, SiegeGame.player.enemyPlayer, data.level);
            });

            SiegeGame.socket.on('game-over-response', function() {
                SiegeGame.player.enemyPlayer.base.health = 0;
                alert('Victory!');
                SiegeGame.game.state.start('GameOver', true, false);
            });

            SiegeGame.player.startTimer();
            SiegeGame.player.incrementGold();
            SiegeGame.game.physics.startSystem(Phaser.Physics.ARCADE);
        }

        public update(): void {
            if (SiegeGame.player && SiegeGame.player.enemyPlayer) {
                if (SiegeGame.player.base.health <= 0) {
                    SiegeGame.player.base.health = 0;
                    SiegeGame.socket.emit('game-over');
                    alert('Defeat!');
                    SiegeGame.game.state.start('GameOver', true, false);
                    this.gameMusic.stop();
                }

                this.map.updateBackground();

                SiegeGame.game.world.bringToTop(SiegeGame.player.base.group);
                SiegeGame.game.world.bringToTop(SiegeGame.player.enemyPlayer.base.group);

                this.map.updateBattlefield();
                this.map.updateForeground();

                this.deleteKilledCharacters(SiegeGame.player);
                this.deleteKilledCharacters(SiegeGame.player.enemyPlayer);

                this.updateCharacters(SiegeGame.player);
                this.updateCharacters(SiegeGame.player.enemyPlayer);

                this.checkCollisions(SiegeGame.player, SiegeGame.player.enemyPlayer);
                this.checkCollisions(SiegeGame.player.enemyPlayer, SiegeGame.player);

                this.userInterface.update(SiegeGame.player);
                SiegeGame.game.world.bringToTop(this.userInterface.group);
            }
        }

        public render(): void {
            // if (SiegeGame.player) {
            //     SiegeGame.player.characters.forEach(function(character) {
            //         SiegeGame.game.debug.body(character.sprite, "#ff0000", false);
            //     }, this);
            // }
        }

        private initialize(data: any): void {
            SiegeGame.player.enemyPlayer = new Player(data);

            // HARDCODED ! fix if more bases are added
            if (SiegeGame.player.position == Position.Left) {
                SiegeGame.player.enemyPlayer.position = Position.Right;
                SiegeGame.player.base = new FrozenCave();
                SiegeGame.player.enemyPlayer.base = new ForestCave();
            } else {
                SiegeGame.player.enemyPlayer.position = Position.Left;
                SiegeGame.player.base = new ForestCave();
                SiegeGame.player.enemyPlayer.base = new FrozenCave();
            }

            this.map = new GrassField();
            this.map.createBackground();

            this.initBase(SiegeGame.player);
            this.initBase(SiegeGame.player.enemyPlayer);

            this.map.createBattlefield();
            this.map.createForeground();

            this.userInterface = new IngameUserInterface();
        }

        private initBase(player: Player): void {
            player.base.initSprites();
            SiegeGame.game.world.bringToTop(player.base.group);

            player.base.group.forEach(function(sprite) {
                SiegeGame.game.physics.arcade.enableBody(sprite);
            }, this);
        }

        private deleteKilledCharacters(player: Player) {
            var characters = [];

            player.characters.forEach(function(character) {
                if (character.sprite.alive) {
                    characters.push(character);
                } else if (player == SiegeGame.player.enemyPlayer) {
                    player.addGold(character.goldCost * 0.3);
                }
            }, this);

            player.characters = characters;
        }

        private updateCharacters(player: Player): void {
            player.characters.forEach(function(character) {
                if (character.health <= 0) {
                    character.currentActionState = Action.Die;
                }

                character.playCurrentState();
                SiegeGame.game.world.bringToTop(character.sprite);
            }, this);
        }

        private checkCollisions(player: Player, enemyPlayer: Player): void {
            // the algorithm is as follows: first check the current character against all enemy characters;
            // if there is no collision => check the same character against the enemy base;
            // again, if no collision => keep moving, else enter fighting state :)

            player.characters.forEach(function(character) {
                var collidesCharacter = false;

                enemyPlayer.characters.forEach(function(enemyCharacter) {
                    var hasCollision = SiegeGame.game.physics.arcade.intersects(character.sprite.body, enemyCharacter.sprite.body);

                    if (hasCollision) {
                        collidesCharacter = true;
                        character.currentActionState = Action.Attack;
                        character.attackCharacter(enemyCharacter);
                    }
                }, this);

                if (!collidesCharacter) {
                    var hasCollision = SiegeGame.game.physics.arcade.intersects(character.sprite.body, enemyPlayer.base.baseSprite.body);

                    if (hasCollision) {
                        character.currentActionState = Action.Attack;
                        character.attackBase(enemyPlayer.base);
                    } else {
                        character.currentActionState = Action.Move;
                    }
                }
            }, this);
        }
    }
}


