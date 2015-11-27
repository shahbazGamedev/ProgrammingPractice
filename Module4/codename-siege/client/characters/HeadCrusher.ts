/// <reference path="./Character.ts"/>

module Siege {
    export class HeadCrusher extends Character {
        constructor(player: Player) {
            this.assetName = 'head-crusher';

            this.spawnY = 338;
            this.scale = 1.1;
            this.goldCost = 50;

            super(160, 900, player);

            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'move'));
            this.animationResetPoints.push(new AnimationResetStats(0, -7, 'die'));
            this.animationResetPoints.push(new AnimationResetStats(50, -22, 'attack'));

            this.levelStats.push(new LevelUpStats(120, 2, 1, 40, 80));
            this.levelStats.push(new LevelUpStats(180, 3, 1.2, 52, 120));
            this.levelStats.push(new LevelUpStats(240, 4, 1.5, 64, 160));

            super.addAnimation('stand', 11, 10);
            super.addAnimation('move', 5, 8);
            super.addAnimation('attack', 10, 15);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 8, 10);
        }
    }
}