/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class HellTurtle extends Character {
        constructor(player: Player) {
            this.assetName = 'hell-turtle';

            this.spawnY = 340;
            this.scale = 0.7;
            this.goldCost = 40;

            super(160, 900, player);

            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'move'));
            this.animationResetPoints.push(new AnimationResetStats(-30, 10, 'die'));
            this.animationResetPoints.push(new AnimationResetStats(20, -45, 'attack'));

            this.levelStats.push(new LevelUpStats(180, 3, 0.7, 60, 120));
            this.levelStats.push(new LevelUpStats(270, 4.5, 0.8, 78, 180));
            this.levelStats.push(new LevelUpStats(360, 6, 1, 96, 240));

            super.addAnimation('stand', 7, 10);
            super.addAnimation('move', 7, 8);
            super.addAnimation('attack', 22, 20);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 10, 12);
        }
    }
}