/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class KarateCat extends Character {
        constructor(player: Player) {
            this.assetName = 'karate-cat';

            this.spawnY = 345;
            this.scale = 0.9;
            this.goldCost = 40;

            super(160, 900, player);

            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'move'));
            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'die'));
            this.animationResetPoints.push(new AnimationResetStats(0, -15, 'attack'));

            this.levelStats.push(new LevelUpStats(120, 6, 1.7, 60, 120));
            this.levelStats.push(new LevelUpStats(156, 9, 1.8, 78, 180));
            this.levelStats.push(new LevelUpStats(192, 12, 2, 96, 240));

            super.addAnimation('stand', 5, 7);
            super.addAnimation('move', 5, 12);
            super.addAnimation('attack', 11, 15);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 11, 12);
        }
    }
}