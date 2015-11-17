/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class FirePig extends Character {
        constructor(player: Player) {
            this.assetName = 'fire-pig';

            this.spawnY = 330;
            this.scale = 0.6;
            this.goldCost = 40;

            super(140, 900, player);

            this.levelStats.push(new LevelUpStats(160, 8, 1.3, 80, 160));
            this.levelStats.push(new LevelUpStats(208, 12, 1.4, 104, 240));
            this.levelStats.push(new LevelUpStats(256, 16, 1.6, 128, 320));

            super.addAnimation('stand', 5, 10);
            super.addAnimation('move', 7, 10);
            super.addAnimation('attack', 19, 15);
            super.addAnimation('hit', 0, 1);
            super.addAnimation('die', 18, 13);
        }
    }
}