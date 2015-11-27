/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Base.ts"/>
/// <reference path="../SiegeGame.ts"/>

module Siege {
    export class FrozenCave extends Base {
        constructor() {
            super();
            this.position = Position.Left;
        }

        private goblin: Phaser.Sprite;
        private hedgehog: Phaser.Sprite;

        public initSprites(): void {
            super.initSprites();
            
            this.baseSprite = SiegeGame.game.add.sprite(50, 180, 'frozen-cave', 'frozen-cave', this.group);
            this.baseSprite.width = 180;
            this.baseSprite.height = 200;

            this.goblin = SiegeGame.game.add.sprite(115, 222, 'frozen-cave', 'goblin-stand000', this.group);
            this.goblin.animations.add('stand', Phaser.Animation.generateFrameNames('goblin-stand', 0, 6, '', 3), 7, true);
            this.goblin.width = 50;
            this.goblin.height = 70;
            this.goblin.animations.play('stand');

            this.hedgehog = SiegeGame.game.add.sprite(75, 318, 'frozen-cave', 'hedgehog-stand000', this.group);
            this.hedgehog.animations.add('stand', Phaser.Animation.generateFrameNames('hedgehog-stand', 0, 5, '', 3), 6, true);
            this.hedgehog.width = 40;
            this.hedgehog.height = 55;
            this.hedgehog.animations.play('stand');

            this.portal = super.initPortalSprite(125, 302, 'frozen-cave');
            this.group.addChild(this.portal);
        }
    }
}