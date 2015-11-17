/// <reference path="../../lib/definitions/phaser.d.ts"/>

module Siege {
    export class GameOverState extends Phaser.State {
        public init(): void {
            SiegeGame.player.resetValues();
        }

        public create(): void {
            this.game.state.start("Menu", true, false);
        }
    }
}


