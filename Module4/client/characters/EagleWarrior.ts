/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="./Character.ts"/>

module Siege {
	export class EagleWarrior extends Character {
		constructor(player: Player) {
			this.assetName = 'eagle-warrior';

			this.spawnY = 347;
			this.scale = 0.8;

			super(140, 900, player);

			this.levelStats.push(new LevelUpStats(80, 4, 1.2, 40, 80));
			this.levelStats.push(new LevelUpStats(104, 6, 1.3, 52, 120));
			this.levelStats.push(new LevelUpStats(128, 8, 1.5, 64, 160));

			super.addAnimation('stand', 9, 10);
			super.addAnimation('move', 3, 8);
			super.addAnimation('attack', 8, 15);
			super.addAnimation('hit', 1, 2);
			super.addAnimation('die', 9, 10);
		}
	}
}