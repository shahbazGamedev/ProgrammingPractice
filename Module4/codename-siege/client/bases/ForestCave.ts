/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Base.ts"/>
/// <reference path="../SiegeGame.ts"/>

module Siege {
    export class ForestCave extends Base {
        constructor() {
            super();
            this.position = Position.Right;
        }

        private rose: Phaser.Sprite;
        private mushroom: Phaser.Sprite;

        public initSprites(): void {
            super.initSprites();

            this.rose = SiegeGame.game.add.sprite(830, 207, 'forest-cave', 'rose-stand000', this.group);
            this.rose.animations
                .add('stand', Phaser.Animation.generateFrameNames('rose-stand', 0, 8, '', 3), 9, true)
                .play();

            this.baseSprite = SiegeGame.game.add.sprite(830, 132, 'forest-cave', 'forest-cave', this.group);
            this.baseSprite.width = 150;
            this.baseSprite.height = 240;

            this.mushroom = SiegeGame.game.add.sprite(915, 324, 'forest-cave', 'mushroom-stand000', this.group);
            this.mushroom.animations
                .add('stand', Phaser.Animation.generateFrameNames('mushroom-stand', 0, 5, '', 3), 6, true)
                .play();

            this.portal = super.initPortalSprite(870, 302, 'forest-cave');
            this.group.addChild(this.portal);
        }
    }
}
