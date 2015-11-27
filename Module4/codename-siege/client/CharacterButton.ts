/// <reference path="../lib/definitions/phaser.d.ts"/>
///<reference path="characters\CharacterType.ts"/>
///<reference path="Player.ts"/>
///<reference path="SiegeGame.ts"/>

module Siege {
    export class CharacterButton {
        public button: Phaser.Button;
        public backgroundFrame: Phaser.Sprite;
        public selectedFrame: Phaser.Sprite;
        public goldText: Phaser.Text;
        public levelText: Phaser.Text;
        public currentLevel: number;
        public character: Character;

        private SIZE: number = SiegeGame.game.width / 15;
        private x: number;
        private y: number;

        public create(data: any): void {
            this.currentLevel = 1;
            this.x = data.x;
            this.y = data.y;

            this.character = Character.getCharacterFromType(data.type, data.player);
            this.character.setLevelStats(this.currentLevel);

            this.initializeBackgroundFrame();
            this.initializeSelectedFrame();
            this.initializeButton(data.type, data.player, data.buttons);
            this.initializeGoldText();
            this.initializeLevelText();

            data.group.addMultiple([
                this.backgroundFrame,
                this.button,
                this.selectedFrame,
                this.goldText,
                this.levelText
            ]);
        }

        public update(): void {
            this.goldText.text = this.character.goldCost.toString();
            this.levelText.text = "Lvl " + this.currentLevel.toString();
        }

        private initializeBackgroundFrame(): void {
            this.backgroundFrame = SiegeGame.game.add.sprite(this.x, this.y, 'GUI', 'charbutton-bg');

            this.backgroundFrame.anchor.set(0.5);
            this.backgroundFrame.width = this.SIZE;
            this.backgroundFrame.height = this.SIZE;
        }

        private initializeSelectedFrame(): void {
            this.selectedFrame = SiegeGame.game.add.sprite(this.x, this.y, 'GUI', 'charbutton-selected');

            this.selectedFrame.anchor.set(0.5);
            this.selectedFrame.width = this.SIZE * 1.1;
            this.selectedFrame.height = this.SIZE * 1.1;
            this.selectedFrame.alpha = 0;
        }

        private initializeButton(type: CharacterType, player: Player, buttons: Array<CharacterButton>): void {
            this.button = SiegeGame.game.add.button(this.x, this.y, this.character.assetName + "-head");

            var offset: number = player.position == Position.Left ? 0 : 1;

            this.button.anchor.set(0.5);
            this.button.width = (0.5 - offset) * -2 * this.SIZE;
            this.button.height = this.SIZE;

            this.button.onInputDown.add(() => {
                if (this.selectedFrame.alpha === 1) {
                    Character.create(type, player, this.currentLevel);
                }

                buttons.forEach(function(button) {
                    button.selectedFrame.alpha = 0;
                }, this)

                this.selectedFrame.alpha = 1;
            });
        }

        private initializeGoldText(): void {
            var style = { fill: '#FFAE00' };
            this.goldText = SiegeGame.game.add.text(
                this.x + this.SIZE / 2,
                this.y - this.SIZE / 2,
                this.character.goldCost.toString(),
                style);

            this.goldText.anchor.setTo(1, 0.2);
            this.goldText.font = 'Geometos';
            this.goldText.fontSize = 20;
            this.goldText.stroke = '#000';
            this.goldText.strokeThickness = 3;
        }

        private initializeLevelText(): void {
            var style = { fill: '#FFF' };
            this.levelText = SiegeGame.game.add.text(
                this.x - this.SIZE / 2,
                this.y + this.SIZE / 2,
                "Lvl " + this.currentLevel.toString(),
                style);

            this.levelText.anchor.setTo(0.1, 0.9);
            this.levelText.font = 'Geometos';
            this.levelText.fontSize = 14;
            this.levelText.stroke = '#000';
            this.levelText.strokeThickness = 3;
        }
    }
}