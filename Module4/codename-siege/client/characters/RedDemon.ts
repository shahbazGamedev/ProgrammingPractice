/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class RedDemon extends Character {
        constructor(player: Player) {
            this.assetName = 'red-demon';

            this.spawnY = 335;
            this.scale = 0.8;
            this.goldCost = 40;

            super(140, 900, player);

            this.levelStats.push(new LevelUpStats(140, 7, 1, 70, 140));
            this.levelStats.push(new LevelUpStats(182, 10.5, 1.1, 91, 210));
            this.levelStats.push(new LevelUpStats(224, 14, 1.3, 112, 280));

            super.addAnimation('stand', 11, 10);
            super.addAnimation('move', 5, 8);
            super.addAnimation('attack', 10, 15);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 8, 10);
        }
    }
}