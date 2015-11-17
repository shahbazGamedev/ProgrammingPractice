/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./IMap.ts"/>
/// <reference path="../SiegeGame.ts"/>

module Siege {
    export class GrassField implements IMap {
        private GAME_HEIGHT: number = SiegeGame.game.height;
        private GAME_WIDTH: number = SiegeGame.game.width;
        private TWICE_GAME_WIDTH: number = SiegeGame.game.width * 2;
        private HALF_GAME_HEIGHT: number = SiegeGame.game.height / 2;
        private HALF_GAME_WIDTH: number = SiegeGame.game.width / 2;

        private sky: Phaser.Image;
        private backgroundMountains: Phaser.Image;
        private lightBeams: Array<Phaser.Sprite>;
        private backgroundCloud: Phaser.Sprite;
        private bird: Phaser.Sprite;

        private battlefield: Phaser.Image;

        private foregroundClouds: Array<Phaser.Sprite>;
        private foregroundMountains: Phaser.Image;

        public createBackground(): void {
            // sky
            this.sky = SiegeGame.game.add.image(0, 0, 'grass-field', 'sky');
            this.sky.width = this.GAME_WIDTH + 100;
            this.sky.x -= 50;
            this.sky.y -= 150;

            // background mountains
            this.backgroundMountains = SiegeGame.game.add.image(0, 0, 'grass-field', 'background-mountains');
            this.backgroundMountains.anchor.set(0.5);
            this.backgroundMountains.reset(this.HALF_GAME_WIDTH, this.HALF_GAME_HEIGHT - 80);
            this.backgroundMountains.scale.x *= -1;
            this.backgroundMountains.alpha = 0.9;

            // light beams
            // don't add for now..
            
            this.generateBackgroundCloud();

            this.generateBird();
        }

        public createBattlefield(): void {
            this.battlefield = SiegeGame.game.add.image(0, 270, 'grass-field', 'battlefield');
        }

        public createForeground(): void {
            // foreground clouds
            this.foregroundClouds = [];

            this.foregroundClouds.push(this.createForegroundCloud(this.HALF_GAME_WIDTH, 500));
            this.foregroundClouds[0].alpha = 0.3;

            this.foregroundClouds.push(this.createForegroundCloud(this.GAME_WIDTH + this.HALF_GAME_WIDTH - 0.9, 500));
            this.foregroundClouds[1].scale.x *= -1;
            this.foregroundClouds[1].alpha = 0.3;

            this.foregroundClouds.push(this.createForegroundCloud(this.HALF_GAME_WIDTH, 505));

            this.foregroundClouds.push(this.createForegroundCloud(this.GAME_WIDTH + this.HALF_GAME_WIDTH - 0.9, 505));
            this.foregroundClouds[3].scale.x *= -1;

            for (var i = 0; i < this.foregroundClouds.length; i++) {
                SiegeGame.game.add.tween(this.foregroundClouds[i])
                    .to({ y: 510 }, Phaser.Timer.SECOND * 2, Phaser.Easing.Linear.None, true, 0, -1)
                    .yoyo(true)
                    .loop(true);
            }
            
            this.foregroundMountains = SiegeGame.game.add.image(50, 445, 'grass-field', 'foreground-mountains');
            this.foregroundMountains.alpha = 0.7;
        }

        public updateBackground(): void {
            if (this.backgroundCloud) {
                this.backgroundCloud.x -= 0.6;
                this.backgroundCloud.y -= 0.1;
            }

            if (this.bird) {
                this.bird.x -= 2;
            }
        }

        public updateBattlefield(): void {
            SiegeGame.game.world.bringToTop(this.battlefield);
        }

        public updateForeground(): void {
            this.foregroundClouds[0].x -= 0.6;
            this.foregroundClouds[1].x -= 0.6;

            this.foregroundClouds[2].x -= 0.3;
            this.foregroundClouds[3].x -= 0.3;

            this.foregroundClouds.forEach(function(cloud) {
                SiegeGame.game.world.bringToTop(cloud);
            });
            
            SiegeGame.game.world.bringToTop(this.foregroundMountains);
        }

        private generateBackgroundCloud(): void {
            var that = this;

            SiegeGame.socket.emit('grassfield-request-background-cloud');

            SiegeGame.socket.on('grassfield-response-background-cloud', function(data) {
                that.backgroundCloud = that.createBackgroundCloud(data.cloudKey, data.y, data.delay);
            });
        }

        private createBackgroundCloud(key: string, y: number, delay: number): Phaser.Sprite {
            var cloud = SiegeGame.game.add.sprite(0, 0, 'grass-field', key);

            cloud.anchor.set(0.5);
            cloud.scale.set(0.2);
            var x: number = this.GAME_WIDTH + cloud.width;
            cloud.reset(x, y);
            cloud.alpha = 0;

            SiegeGame.game.physics.arcade.enableBody(cloud);
            cloud.checkWorldBounds = true;

            cloud.events.onEnterBounds.add(function() {
                SiegeGame.game.add.tween(cloud)
                    .to({ alpha: 1 }, Phaser.Timer.SECOND, Phaser.Easing.Linear.None, true);

                SiegeGame.game.add.tween(cloud.scale)
                    .to({ x: 1.65, y: 1.4 }, Phaser.Timer.SECOND * 15, Phaser.Easing.Linear.None, true, Phaser.Timer.HALF);

                cloud.events.onOutOfBounds.add(function() {
                    SiegeGame.game.time.events.add(Phaser.Timer.SECOND * delay, this.generateBackgroundCloud, this);
                }, this);
            }, this);

            return cloud;
        }

        private generateBird(): void {
            var that = this;

            SiegeGame.socket.emit('grassfield-request-bird');

            SiegeGame.socket.on('grassfield-response-bird', function(data) {
                that.bird = that.createBird(data.y, data.delay);
            });
        }

        private createBird(y: number, delay: number): Phaser.Sprite {
            var bird = SiegeGame.game.add.sprite(0, 0, 'grass-field', 'bird-fly000');

            var x: number = this.GAME_WIDTH + bird.width;

            bird.anchor.set(0.5);
            bird.scale.set(0.1);
            bird.reset(x, y);
            bird.alpha = 0;

            bird.animations
                .add('fly', Phaser.Animation.generateFrameNames('bird-fly', 0, 4, '', 3), 10, true)
                .play();

            SiegeGame.game.physics.arcade.enableBody(bird);
            bird.checkWorldBounds = true;

            bird.events.onEnterBounds.add(function() {
                SiegeGame.game.add.tween(bird)
                    .to({ alpha: 1 }, Phaser.Timer.SECOND, Phaser.Easing.Linear.None, true);

                SiegeGame.game.add.tween(bird)
                    .to({ y: 150 }, Phaser.Timer.SECOND * 10, Phaser.Easing.Linear.None, true);

                SiegeGame.game.add.tween(bird.scale)
                    .to({ x: 0.4, y: 0.4 }, Phaser.Timer.SECOND * 10, Phaser.Easing.Linear.None, true);

                bird.events.onOutOfBounds.add(function() {
                    SiegeGame.game.time.events.add(Phaser.Timer.MINUTE * delay, this.generateBird, this);
                }, this);
            }, this);

            return bird;
        }

        private createForegroundCloud(x: number, y: number): Phaser.Sprite {
            var cloud: Phaser.Sprite;

            cloud = SiegeGame.game.add.sprite(0, 0, 'grass-field', 'foreground-clouds');
            cloud.anchor.set(0.5);
            cloud.reset(x, y);

            SiegeGame.game.physics.arcade.enableBody(cloud);
            cloud.checkWorldBounds = true;

            var resetX = this.GAME_WIDTH + this.HALF_GAME_WIDTH - 2.2;
            cloud.events.onOutOfBounds.add(this.resetForegroundCloudPosition, this, null, resetX);

            return cloud;
        }

        private resetForegroundCloudPosition(cloud: Phaser.Sprite, x: number) {
            cloud.reset(x, cloud.y);
        }
    }
}