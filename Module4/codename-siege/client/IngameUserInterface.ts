/// <reference path='../lib/definitions/phaser.d.ts'/>
/// <reference path='SiegeGame.ts'/>
/// <reference path='Player.ts'/>
///<reference path="CharacterButton.ts"/>

module Siege {
    export class IngameUserInterface {
        constructor() {
            this.group = new Phaser.Group(SiegeGame.game);
            this.panelGroup = new Phaser.Group(SiegeGame.game);

            this.printName(SiegeGame.player);
            this.printName(SiegeGame.player.enemyPlayer);

            this.playerHealthText = this.createHealth(SiegeGame.player);
            this.enemyPlayerHealthText = this.createHealth(SiegeGame.player.enemyPlayer);

            this.playerGoldText = this.createGold(SiegeGame.player);
            
            this.timer = this.createTimer(SiegeGame.player);
            
            this.createPanel(SiegeGame.player);

            SiegeGame.game.world.bringToTop(this.group);
        }

        public group: Phaser.Group;

        private panelGroup: Phaser.Group;
        private playerHealthText: Phaser.Text;
        private enemyPlayerHealthText: Phaser.Text;
        private playerGoldText: Phaser.Text;
        private timer: Phaser.Text;
        private selectedButton: CharacterButton;
        private selectedButtonDamage: Phaser.Text;
        private selectedButtonHealth: Phaser.Text;
        private selectedButtonAttackSpeed: Phaser.Text;
        private selectedButtonVelocity: Phaser.Text;
        private characterButtons: Array<CharacterButton>;
        private upgradeButton: Phaser.Button;

        public update(player: Player): void {
            this.playerHealthText.text = Math.round(player.base.health).toString();
            this.enemyPlayerHealthText.text = Math.round(player.enemyPlayer.base.health).toString();
            this.playerGoldText.text = Math.round(player.gold).toString();
            
            this.timer.text = this.getTimerText();
            
            this.characterButtons.forEach(function(charButton) {
                charButton.update();
            });

            if (this.selectedButton) {
                this.selectedButton.character.setLevelStats(this.selectedButton.currentLevel);

                this.selectedButtonDamage.text = this.selectedButton.character.damage.toString();
                this.selectedButtonHealth.text = this.selectedButton.character.health.toString();
                this.selectedButtonAttackSpeed.text = Math.floor(this.selectedButton.character.attackSpeed).toString();
                this.selectedButtonVelocity.text = this.selectedButton.character.velocity.toString();
            }
        }

        private createPanel(player: Player): void {
            // panel
            var panelBody = SiegeGame.game.add.sprite(SiegeGame.game.width / 2, SiegeGame.game.height + 10, 'GUI', 'panel-body', this.panelGroup);
            panelBody.anchor.set(0.5, 1.1);

            this.selectedButtonDamage = this.createPanelText(panelBody.x - panelBody.width / 5, panelBody.y - panelBody.height / 1.9);

            this.selectedButtonHealth = this.createPanelText(panelBody.x + panelBody.width / 5, panelBody.y - panelBody.height / 1.9);

            this.selectedButtonAttackSpeed = this.createPanelText(panelBody.x - panelBody.width / 5, panelBody.y - panelBody.height / 3.7);

            this.selectedButtonVelocity = this.createPanelText(panelBody.x + panelBody.width / 5, panelBody.y - panelBody.height / 3.7);

            this.initializeCharacterButtons(player, panelBody);

            this.group.add(this.panelGroup);
        }

        private initializeCharacterButtons(player: Player, panelBody: Phaser.Sprite): void {
            var that = this;

            that.characterButtons = [];

            player.chosenCharacters.forEach(function(characterType) {
                var index = player.chosenCharacters.indexOf(characterType);

                var characterButtonX = (panelBody.x - panelBody.width / 2) + ((index + 0.5) / player.chosenCharacters.length) * panelBody.width;

                var characterButtonY = panelBody.y - panelBody.height * 1.1;

                that.characterButtons[index] = new CharacterButton();

                var buttonCreateData = {
                    type: characterType,
                    x: characterButtonX,
                    y: characterButtonY,
                    buttons: that.characterButtons,
                    player: player,
                    group: that.panelGroup
                };

                that.characterButtons[index].create(buttonCreateData);

                that.characterButtons[index].button.onInputDown.add(() => {
                    that.selectedButton = that.characterButtons[index];
                    var clickSound = SiegeGame.game.add.audio('button-click', 1, false);
                    clickSound.play();
                    var upgradeButtonX = panelBody.x + panelBody.width / 2.5;
                    var upgradeButtonY = panelBody.y - panelBody.height / 2.3;
                    that.upgradeButton = that.createUpgradeButton(player, upgradeButtonX, upgradeButtonY);
                })
            });
        }

        private createUpgradeButton(player: Player, x: number, y: number): Phaser.Button {
            var button = SiegeGame.game.add.button(x, y, 'GUI');
            button.frameName = 'upgrade-button';
            button.anchor.set(0.5);
            this.panelGroup.add(button.animations.sprite);

            var textStyle = { fill: '#FFF' };
            var upgradeText: Phaser.Text = SiegeGame.game.add.text(x, y, "UPGRADE", textStyle, this.panelGroup);
            upgradeText.anchor.setTo(0.5, 1.2);
            upgradeText.font = 'Geometos';
            upgradeText.fontSize = 18;
            upgradeText.stroke = '#000';
            upgradeText.strokeThickness = 4;

            var priceStyle = { fill: '#FFAE00' };
            var priceText = SiegeGame.game.add.text(x, y, this.selectedButton.character.upgradePrice.toString(), priceStyle, this.panelGroup);
            priceText.anchor.setTo(0.5, 0.2);
            priceText.font = 'Geometos';
            priceText.fontSize = 35;
            priceText.stroke = '#000';
            priceText.strokeThickness = 4;

            button.onInputDown.add(() => {
                if (this.selectedButton.currentLevel < 3) {
                    if (player.gold >= this.selectedButton.character.upgradePrice) {
                        player.takeGold(this.selectedButton.character.upgradePrice);

                        this.selectedButton.currentLevel++;

                        this.selectedButton.character.setLevelStats(this.selectedButton.currentLevel);

                        priceText.text = this.selectedButton.character.upgradePrice.toString();

                        if (this.selectedButton.currentLevel >= 3) {
                            priceText.text = "MAX";
                        }
                        var levelUp = SiegeGame.game.add.audio('level-up', 2, false);
                        levelUp.play();
                    }
                }
            });

            if (this.selectedButton.currentLevel >= 3) {
                priceText.text = "MAX";
            }

            return button;
        }

        private createPanelText(x: number, y: number): Phaser.Text {
            var style = { fill: '#DEDDDD' };
            var text: Phaser.Text = SiegeGame.game.add.text(x, y, "-", style, this.panelGroup);

            text.anchor.setTo(1);
            text.font = 'Geometos';
            text.fontSize = 17;
            text.stroke = '#000';
            text.strokeThickness = 4;

            return text;
        }

        private printName(player: Player): void {
            var nameTextStyle = { fill: '#FFF' };
            var nameText = SiegeGame.game.add.text(player.base.baseSprite.x + player.base.baseSprite.width / 2, SiegeGame.game.height / 2.8, player.name.toString(), nameTextStyle, this.group);

            nameText.anchor.setTo(0.5);
            nameText.font = 'Geometos';
            nameText.fontSize = 20;
            nameText.stroke = '#000';
            nameText.strokeThickness = 3;
        }

        private createHealth(player: Player): Phaser.Text {
            var style = { fill: '#0DFF21' };
            var text = SiegeGame.game.add.text(player.base.baseSprite.x + player.base.baseSprite.width / 2,
                SiegeGame.game.height / 2.5, Math.round(player.base.health).toString(), style, this.group);

            text.anchor.setTo(0.5);
            text.font = 'Geometos';
            text.fontSize = 17;
            text.stroke = '#000';
            text.strokeThickness = 3;

            return text;
        }

        private createGold(player: Player): Phaser.Text {
            var style = { fill: '#FFAE00' };
            var text = SiegeGame.game.add.text(player.base.baseSprite.x + player.base.baseSprite.width / 2.4,
                SiegeGame.game.height / 3.5, Math.round(player.gold).toString(), style, this.group);

            text.font = 'Geometos';
            text.fontSize = 18;
            text.stroke = '#000';
            text.strokeThickness = 3;

            return text;
        }

        private createTimer(player: Player) {
            var style = { fill: '#FFF' };
            var text = SiegeGame.game.add.text(SiegeGame.game.width / 2.31, 1, this.getTimerText(), style, this.group);

            text.font = 'Geometos';
            text.fontSize = 40;
            text.stroke = '#000';
            text.strokeThickness = 3;

            return text;
        }
        
        private getTimerText():string {
            var minutes = SiegeGame.player.gameMinutes < 10 ? '0' + SiegeGame.player.gameMinutes : SiegeGame.player.gameMinutes;
            var seconds = SiegeGame.player.gameSeconds < 10 ? '0' + SiegeGame.player.gameSeconds : SiegeGame.player.gameSeconds;
            
            return minutes + ':' + seconds;
        }
    }
}