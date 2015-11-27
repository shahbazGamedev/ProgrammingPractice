/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class Vulture extends Character {
        constructor(player: Player) {
            this.assetName = 'vulture';

            this.spawnY = 315;
            this.scale = 1;
            this.goldCost = 40;
			 
            super(160, 900, player);

            this.levelStats.push(new LevelUpStats(200, 10, 1.5, 100, 200));
            this.levelStats.push(new LevelUpStats(260, 15, 1.6, 130, 375));
            this.levelStats.push(new LevelUpStats(320, 20, 1.8, 160, 450));

            super.addAnimation('stand', 5, 7);
            super.addAnimation('move', 5, 7);
            super.addAnimation('attack', 18, 20);
            super.addAnimation('hit', 1, 2);
            super.addAnimation('die', 10, 12);
        }
    }
}