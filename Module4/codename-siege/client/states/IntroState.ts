/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="../SiegeGame.ts"/>

module Siege {
    export class IntroState extends Phaser.State {
        private zariba: Phaser.Sprite;
        private academy: Phaser.Sprite;
        private blue: Phaser.Sprite;
        private green: Phaser.Sprite;
        private hat: Phaser.Sprite;
        private line: Phaser.Sprite;
        private offsetX: number = 115;
        private offsetY: number = -170;

        public create():void {
            // initialize
            this.blue = SiegeGame.game.add.sprite(-265, -280, "blue");
            this.green = SiegeGame.game.add.sprite(510, 60, "green");
            this.hat = SiegeGame.game.add.sprite(this.offsetX, this.offsetY, "hat");
            this.hat.alpha = 0;
            this.line = SiegeGame.game.add.sprite(-535, 714, "line");

            this.zariba = SiegeGame.game.add.sprite(SiegeGame.game.world.centerX, SiegeGame.game.world.centerY * 1.4, "zariba");
            this.zariba.anchor.set(0.5, 0.5);
            this.zariba.alpha = 0;

            this.academy = SiegeGame.game.add.sprite(SiegeGame.game.world.centerX, SiegeGame.game.world.centerY * 1.65, "academy");
            this.academy.anchor.set(0.5, 0.5);
            this.academy.alpha = 0;

            // animate NOW
            this.bluePart();
            this.greenPart();
            SiegeGame.game.time.events.add(Phaser.Timer.SECOND * 2, this.whiteLine, this);
            SiegeGame.game.time.events.add(Phaser.Timer.SECOND * 3, this.fadeHat, this);
            SiegeGame.game.time.events.add(Phaser.Timer.SECOND * 5, this.fadeZariba, this);
            SiegeGame.game.time.events.add(Phaser.Timer.SECOND * 4, this.fadeAcademy, this);

            // next State
            SiegeGame.game.time.events.add(8000, () => {
                SiegeGame.game.state.start("Menu");
            }, this);
        }

        private bluePart():void {
            SiegeGame.game.add.tween(this.blue).to({x: this.offsetX, y: this.offsetY}, 2000,
                Phaser.Easing.Bounce.Out, true);
        }
        private greenPart():void {
            SiegeGame.game.add.tween(this.green).to({x: this.offsetX, y: this.offsetY}, 2000,
                Phaser.Easing.Bounce.Out, true);
        }
        private whiteLine():void {
            SiegeGame.game.add.tween(this.line).to({x: this.offsetX, y: this.offsetY}, 500,
                Phaser.Easing.Default, true);
        }
        private fadeHat():void {
            SiegeGame.game.add.tween(this.hat).to({alpha: 1}, 2200,
                Phaser.Easing.Default, true);
        }

        private fadeZariba():void {
            SiegeGame.game.add.tween(this.zariba.scale).to({x: 1, y: 1}, 3000, Phaser.Easing.Exponential.Out, true);
            SiegeGame.game.add.tween(this.zariba).to({alpha: 1}, 3000,
                Phaser.Easing.Default, true);
        }

        private fadeAcademy():void {
            SiegeGame.game.add.tween(this.academy.scale).to({x: 1, y: 1}, 3000, Phaser.Easing.Exponential.Out, true);
            SiegeGame.game.add.tween(this.academy).to({alpha: 1}, 3000,
                Phaser.Easing.Default, true);
        }
    }
}


