/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="../SiegeGame.ts"/>

module Siege {
    export class Base {
        constructor() {
            this.group = new Phaser.Group(SiegeGame.game);

            this.health = 1000;
        }

        public baseSprite: Phaser.Sprite;
        public group: Phaser.Group;
        public position: Position;
        public health: number;

        protected portal: Phaser.Sprite;

        public initSprites(): void {

        }

        public initPortalSprite(x: number, y: number, cacheKey: string): Phaser.Sprite {
            var portal: Phaser.Sprite;

            portal = SiegeGame.game.add.sprite(x, y, cacheKey, 'portal-spawn000');
            portal.animations
                .add('spawn', Phaser.Animation.generateFrameNames('portal-spawn', 0, 13, '', 3), 14, true);
            portal.width = 50;
            portal.height = 70;
            portal.alpha = 0.6;
            portal.animations
                .play('spawn');

            return portal;
        }

        public takeDamage(damage: number) {
            this.health -= damage;
        }
    }
}