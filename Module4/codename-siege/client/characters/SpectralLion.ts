/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class SpectralLion extends Character {
        constructor(player: Player) {
            this.assetName = 'spectral-lion';

            this.spawnY = 325;
            this.scale = 0.7;
            this.goldCost = 40;

            super(140, 900, player);

            this.animationResetPoints.push(new AnimationResetStats(0, 0, 'move'));
            this.animationResetPoints.push(new AnimationResetStats(-30, 10, 'die'));
            this.animationResetPoints.push(new AnimationResetStats(50, 0, 'attack'));

            this.levelStats.push(new LevelUpStats(150, 2.5, 1.4, 50, 100));
            this.levelStats.push(new LevelUpStats(130, 3.75, 1.5, 65, 150));
            this.levelStats.push(new LevelUpStats(160, 5, 1.7, 80, 200));

            super.addAnimation('stand', 7, 9);
            super.addAnimation('move', 3, 8);
            super.addAnimation('attack', 8, 10);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 4, 10);
        }
    }
}