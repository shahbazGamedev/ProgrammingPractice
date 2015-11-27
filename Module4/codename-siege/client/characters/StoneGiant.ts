/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class StoneGiant extends Character {
        constructor(player: Player) {
            this.assetName = 'stone-giant';

            this.spawnY = 315;
            this.scale = 0.8;
            this.goldCost = 40;

            super(160, 900, player);

            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'move'));
            this.animationResetPoints.push(new AnimationResetStats(-50, 0, 'die'));
            this.animationResetPoints.push(new AnimationResetStats(30, -20, 'attack'));

            this.levelStats.push(new LevelUpStats(300, 5, 0.5, 100, 200));
            this.levelStats.push(new LevelUpStats(450, 7.5, 0.6, 130, 300));
            this.levelStats.push(new LevelUpStats(600, 10, 0.8, 160, 400));

            super.addAnimation('stand', 5, 7);
            super.addAnimation('move', 11, 10);
            super.addAnimation('attack', 21, 20);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 7, 10);
        }
    }
}