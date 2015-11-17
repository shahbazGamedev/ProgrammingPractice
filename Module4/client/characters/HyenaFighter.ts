/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class HyenaFighter extends Character {
        constructor(player: Player) {
            this.assetName = 'hyena-fighter';

            this.spawnY = 325;
            this.scale = 0.7;

            super(160, 900, player);

            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'move'));
            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'die'));
            this.animationResetPoints.push(new AnimationResetStats(30, -20, 'attack'));

            this.levelStats.push(new LevelUpStats(240, 4, 1.1, 80, 160));
            this.levelStats.push(new LevelUpStats(360, 6, 1.2, 104, 240));
            this.levelStats.push(new LevelUpStats(480, 8, 1.4, 128, 320));

            super.addAnimation('stand', 7, 10);
            super.addAnimation('move', 11, 10);
            super.addAnimation('attack', 13, 17);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 17, 20);
        }
    }
}