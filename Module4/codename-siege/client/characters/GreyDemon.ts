/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class GreyDemon extends Character {
        constructor(player: Player) {
            this.assetName = 'grey-demon';

            this.spawnY = 325;
            this.scale = 0.7;
            this.goldCost = 40;

            super(150, 900, player);

            this.levelStats.push(new LevelUpStats(100, 5, 1, 50, 100));
            this.levelStats.push(new LevelUpStats(130, 7.5, 1.5, 65, 150));
            this.levelStats.push(new LevelUpStats(160, 10, 2, 80, 200));

            super.addAnimation('stand', 11, 10);
            super.addAnimation('move', 5, 8);
            super.addAnimation('attack', 11, 15);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 8, 10);
        }
    }
}