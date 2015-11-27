/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
    export class SteelPig extends Character {
        constructor(player: Player) {
            this.assetName = 'steel-pig';

            this.spawnY = 330;
            this.scale = 0.6;
            this.goldCost = 40;

            super(140, 900, player);

            this.levelStats.push(new LevelUpStats(210, 3.5, 1, 70, 140));
            this.levelStats.push(new LevelUpStats(315, 5.25, 1.1, 91, 210));
            this.levelStats.push(new LevelUpStats(420, 7, 1.3, 112, 280));

            super.addAnimation('stand', 5, 10);
            super.addAnimation('move', 7, 10);
            super.addAnimation('attack', 19, 15);
            super.addAnimation('hit', 0, 1);
            super.addAnimation('die', 18, 13);
        }
    }
}