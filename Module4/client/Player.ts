/// <reference path="./characters/Character.ts"/>

module Siege {
    // main client entity
    export class Player {
        constructor(data: any) {
            this.id = data.id;
            this.name = data.name;
            this.level = data.level;
            this.experience = data.experience;
            this.currency = data.currency;

            this.resetValues();

            data.characters = data.characters.split(', ');
            for (var i = 0; i < data.characters.length; i++) {
                data.characters[i] = parseInt(data.characters[i]);
            }
            this.availableCharacters = data.characters;
        }

        public incrementGold(): void {
            SiegeGame.game.time.events.add(Phaser.Timer.SECOND / 2, () => {
                var incrementValue;

                if (this.gameMinutes < 1) {
                    incrementValue = 1;
                } else if (this.gameMinutes >= 1 && this.gameMinutes < 3) {
                    incrementValue = 2;
                } else if (this.gameMinutes >= 3 && this.gameMinutes < 5) {
                    incrementValue = 3;
                } else {
                    incrementValue = 4;
                }

                this.addGold(incrementValue);
            }, this).loop = true;
        }

        public addGold(value: number): void {
            this.gold += value;
        }

        public takeGold(value: number): void {
            this.gold -= value;
        }

        public resetValues(): void {
            this.gold = 1;
            this.characters = [];
            this.gameSeconds = 0;
            this.gameMinutes = 0;
        }

        public startTimer(): void {
            SiegeGame.game.time.events.add(Phaser.Timer.SECOND, () => {
                if (this.gameSeconds == 59) {
                    this.gameSeconds = 0;
                } else {
                    this.gameSeconds += 1;
                }
            }, this).loop = true;

            SiegeGame.game.time.events.add(Phaser.Timer.MINUTE, () => {
                this.gameMinutes += 1;
            }, this).loop = true;
        }

        public id: number;
        public name: string;
        public level: number;
        public experience: number;
        public currency: number;
        public position: Position;
        public gold: number;
        public base: Base;
        // array which stores current characters on the battlefield
        public characters: any;
        // the ones a player can choose before the start of the game
        public availableCharacters: any;
        // the ones a player can use in the game
        public chosenCharacters: any;
        public enemyPlayer: Player;
        public gameSeconds: number;
        public gameMinutes: number;

        private giveGold: boolean = false;
    }
}