/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="../../lib/definitions/EZGUI.d.ts"/>
/// <reference path="../SiegeGame.ts"/>

declare var $: any;

module Siege {
    export class MenuState extends Phaser.State {
        private menuMusic;

        private CHARACTER_SELECT_SIZE = 250;
        private CHARACTER_SELECT_HOVERED_SIZE = this.CHARACTER_SELECT_SIZE + 10;
        private CHARACTER_SELECT_CLICKED_SIZE = this.CHARACTER_SELECT_SIZE + 20;

        private characters: any;
        private overlay: Phaser.Image;
        private selectedCharacters: any;
        private searchStarted: boolean;

        private playButton: any;
        private storeButton: any;
        private leaderboardButton: any;
        private profileButton: any;
        private charactersSelectList: any;

        private mainContainer: any;
        private playContainer: any;
        private storeContainer: any;
        private leaderboardContainer: any;
        private profileContainer: any;


        public init(): void {
            SiegeGame.socket.on('assign-position', function(data) {
                Siege.SiegeGame.player.position = data.position;
            });

            SiegeGame.socket.on('game-begin', function() {
                for (var component in EZGUI.components) {
                    if (EZGUI.components.hasOwnProperty(component)) {
                        EZGUI.components[component].visible = false;
                        EZGUI.components[component].destroy();
                    }
                }

                SiegeGame.game.state.start('Game', true, false);
            });

            this.selectedCharacters = [];
            this.searchStarted = false;
            this.initializeElements();
        }

        public create(): void {
            this.menuMusic = SiegeGame.game.add.audio('menu-music',1,true);
            this.menuMusic.play();
            var that = this;

            var sky = SiegeGame.game.add.sprite(-50, 0, 'menu', 'sky.png');
            sky.width = SiegeGame.game.width + 100;

            var background = SiegeGame.game.add.sprite(-1, 220, 'menu', 'menu-background.png');

            EZGUI.Theme.load(['client/assets/kenney-theme/kenney-theme.json'], function() {
                var container = EZGUI.create(that.mainContainer, 'kenney');

                that.initializeButton(that.playButton);
                that.initializeButton(that.storeButton);
                that.initializeButton(that.leaderboardButton);
                that.initializeButton(that.profileButton);

                that.initializeContainer(that.playContainer);
                that.initializeContainer(that.storeContainer);
                that.initializeContainer(that.leaderboardContainer);
                that.initializeContainer(that.profileContainer);
                
                // reflection, bitch :D
                for (var key in EZGUI.components) {
                    if (EZGUI.components.hasOwnProperty(key) && key.search('SelectContainer') !== -1) {
                        var container = EZGUI.components[key];
                        that.initializeCharacterSelectContainer(container);
                    }
                }
            });
        }

        public update(): void {
            if (this.selectedCharacters.length == 4 && !this.searchStarted) {
                SiegeGame.socket.emit('searching-game', { name: SiegeGame.player.name });
                SiegeGame.player.chosenCharacters = this.selectedCharacters;
                this.searchStarted = true;
                this.menuMusic.stop();
            }
        }

        private initializeElements(): void {
            this.characters = {
                'EagleWarrior': {
                    text: 'Eagle Warrior',
                    value: 0
                },
                'FirePig': {
                    text: 'Fire Pig',
                    value: 1
                },
                'GreyDemon': {
                    text: 'Grey Demon',
                    value: 2
                },
                'HeadCrusher': {
                    text: 'Head Crusher',
                    value: 3
                },
                'RedDemon': {
                    text: 'Red Demon',
                    value: 4
                },
                'SpectralLion': {
                    text: 'Spectral Lion',
                    value: 5
                },
                'SteelPig': {
                    text: 'Steel Pig',
                    value: 6
                },
                'HellTurtle': {
                    text: 'Hell Turtle',
                    value: 7
                },
                'HyenaFighter': {
                    text: 'Hyena Fighter',
                    value: 8
                },
                'KarateCat': {
                    text: 'Karate Cat',
                    value: 9
                },
                'StoneGiant': {
                    text: 'Stone Giant',
                    value: 10
                },
                'Vulture': {
                    text: 'Vulture',
                    value: 11
                }
            };

            this.mainContainer = {
                id: 'mainContainer',
                component: 'MenuContainer',
                width: SiegeGame.game.width,
                height: SiegeGame.game.height,
                position: { x: 0, y: 0 }
            };

            this.playButton = {
                id: 'playButton',
                text: 'PLAY',
                component: 'Button',
                skin: 'BlueButton',
                font: {
                    size: '60px',
                    color: 'white'
                },
                padding: 10,
                position: { x: 370, y: 195 },
                width: 250,
                height: 90
            };

            this.storeButton = {
                id: 'storeButton',
                text: 'Store',
                component: 'Button',
                skin: 'BlueButton',
                font: {
                    size: '28px',
                    color: 'white'
                },
                padding: 10,
                position: { x: 190, y: 490 },
                width: 150,
                height: 50
            };

            this.leaderboardButton = {
                id: 'leaderboardButton',
                text: 'Leaderboard',
                component: 'Button',
                skin: 'BlueButton',
                font: {
                    size: '28px',
                    color: 'white'
                },
                padding: 10,
                position: { x: 370, y: 490 },
                width: 250,
                height: 50
            };

            this.profileButton = {
                id: 'profileButton',
                text: 'Profile',
                component: 'Button',
                skin: 'BlueButton',
                font: {
                    size: '28px',
                    color: 'white'
                },
                padding: 10,
                position: { x: 650, y: 490 },
                width: 150,
                height: 50
            };

            this.charactersSelectList = {
                id: 'charactersSelectList',
                component: 'List',
                skin: 'CharactersSelectList',
                position: { x: 0, y: 15 },
                dragY: false,
                width: 630,
                height: 330,
                layout: [2, 1],
                children: this.getPlayContainerCharacters()
            };

            this.playContainer = {
                id: 'playContainer',
                component: 'Window',
                padding: 10,
                height: 320,
                width: SiegeGame.game.width / 1.6,
                position: { x: SiegeGame.game.width / 5.4, y: SiegeGame.game.height / 6 },
                children: [
                    this.charactersSelectList
                ]
            };

            this.storeContainer = {
                id: 'storeContainer',
                component: 'Window',
                text: 'Coming soon',
                padding: 20,
                height: 350,
                width: 340,
                position: { x: SiegeGame.game.width / 3.2, y: SiegeGame.game.height / 6 },
                font: {
                    size: '30px',
                    color: 'grey'
                }
            };

            this.leaderboardContainer = {
                id: 'leaderboardContainer',
                component: 'Window',
                text: 'Coming soon',
                padding: 20,
                height: 350,
                width: 340,
                position: { x: SiegeGame.game.width / 3.2, y: SiegeGame.game.height / 6 },
                font: {
                    size: '30px',
                    color: 'grey'
                }
            };

            this.profileContainer = {
                id: 'profileContainer',
                component: 'Window',
                padding: 20,
                height: 350,
                width: 340,
                position: { x: SiegeGame.game.width / 3.2, y: SiegeGame.game.height / 6 },
                font: {
                    size: '30px',
                    color: 'grey'
                },
                layout: [3, 1],
                children: [
                    {
                        component: 'Label',
                        id: 'PlayerName',
                        text: SiegeGame.player.name.toString() + '\t',
                        width: 320,
                        height: 100,
                        position: 'top left',
                        font: {
                            size: '40px',
                            color: 'grey'
                        }
                    },
                    {
                        component: 'Label',
                        id: 'PlayerLevel',
                        text: 'Level ' + SiegeGame.player.level.toString() + '\t',
                        width: 320,
                        height: 130,
                        position: 'center center',
                        font: {
                            size: '30px',
                            color: 'grey'
                        }
                    },
                    {
                        component: 'Label',
                        id: 'PlayerXP',
                        text: 'XP ' + SiegeGame.player.experience.toString() + '\t',
                        width: 320,
                        height: 100,
                        position: 'bottom right',
                        font: {
                            size: '30px',
                            color: 'grey'
                        }
                    }
                ]
            };
        }

        private changeCursorToDefault(): void {
            $('canvas').css('cursor', 'default');
        }

        private changeCursorToPointer(): void {
            $('canvas').css('cursor', 'pointer');
        }

        private initializeButton(json: any): void {
            var that = this;

            var button = EZGUI.create(json, 'kenney');

            button.tween = SiegeGame.game.add.tween(button)
                .to({ y: button.y - 5 }, Phaser.Timer.SECOND / 10, Phaser.Easing.Linear.None, false, 0, 0, true);

            button.on('mouseover', function() {
                that.changeCursorToPointer();

                if (!button.tween.isRunning) {
                    button.tween.start();
                }
            });

            button.on('click', function() {
                var containerToShow: any;

                switch (json.id) {
                    case 'playButton':
                        containerToShow = EZGUI.components.playContainer;
                        break;
                    case 'storeButton':
                        containerToShow = EZGUI.components.storeContainer;
                        break;
                    case 'leaderboardButton':
                        containerToShow = EZGUI.components.leaderboardContainer;
                        break;
                    case 'profileButton':
                        containerToShow = EZGUI.components.profileContainer;
                        break;
                }

                that.changeCursorToDefault();

                if (containerToShow) {
                    that.hideUI(containerToShow);
                }
            });

            button.on('mouseout', function() {
                that.changeCursorToDefault();

                if (!button.tween.isRunning) {
                    button.tween = SiegeGame.game.add.tween(button)
                        .to({ y: button.y - 5 }, Phaser.Timer.SECOND / 10, Phaser.Easing.Linear.None, false, 0, 0, true);
                }
            });

            EZGUI.components.mainContainer.addChild(button);
        }

        private initializeContainer(json: any): void {
            var container = EZGUI.create(json, 'kenney');
            container.alpha = 0;
            container.visible = false;
            EZGUI.components.mainContainer.addChild(container);
        }

        private getPlayContainerCharacters(): any {
            var children = [];

            var that = this;

            for (var key in that.characters) {
                if (that.characters.hasOwnProperty(key)) {
                    if (SiegeGame.player.availableCharacters.indexOf(that.characters[key].value) != -1) {
                        var json = {
                            id: key + 'SelectContainer',
                            text: that.characters[key].text,
                            userData: that.characters[key].value,
                            component: 'Window',
                            position: {
                                x: 20,
                                y: 10
                            },
                            anchor: {
                                x: 0.5,
                                y: 0.5
                            },
                            width: that.CHARACTER_SELECT_SIZE,
                            height: that.CHARACTER_SELECT_SIZE,
                            font: {
                                size: '24px',
                                color: 'grey'
                            },
                        };

                        children.push(json);
                    }
                }
            }

            return children;
        }

        private initializeCharacterSelectContainer(container: any): void {
            var that = this;

            container.clicked = false;
            container.hovered = false;

            container.on('mouseover', function() {
                that.changeCursorToPointer();

                if (!container.hovered && !container.clicked) {
                    container.hovered = true;

                    container.animateSizeTo(that.CHARACTER_SELECT_HOVERED_SIZE, that.CHARACTER_SELECT_HOVERED_SIZE, 10);
                }
            });

            container.on('click', function() {
                var character = container.userData;

                if (!container.clicked) {
                    if (that.selectedCharacters.length <= 4) {
                        that.selectedCharacters.push(character);
                        container.clicked = true;
                        container.animateSizeTo(that.CHARACTER_SELECT_CLICKED_SIZE, that.CHARACTER_SELECT_CLICKED_SIZE, 10);
                    }
                } else {
                    that.selectedCharacters.splice(that.selectedCharacters.indexOf(character), 1);
                    container.clicked = false;
                    container.animateSizeTo(that.CHARACTER_SELECT_SIZE, that.CHARACTER_SELECT_SIZE, 10);
                }
            });

            container.on('mouseout', function() {
                that.changeCursorToDefault();

                if (container.hovered && !container.clicked) {
                    container.hovered = false;

                    container.animateSizeTo(that.CHARACTER_SELECT_SIZE, that.CHARACTER_SELECT_SIZE, 10);
                }
            });
        }

        private showUI(): void {
            var that = this;

            this.showButton(EZGUI.components.playButton);
            this.showButton(EZGUI.components.storeButton);
            this.showButton(EZGUI.components.leaderboardButton);
            this.showButton(EZGUI.components.profileButton);

            SiegeGame.game.add.tween(that.overlay)
                .to({ alpha: 0 }, Phaser.Timer.SECOND / 4, Phaser.Easing.Linear.None, true, 0)
                .onComplete.addOnce(function() {
                    that.overlay.destroy();
                });
        }

        private hideUI(container: any): void {
            var that = this;

            this.hideButton(EZGUI.components.playButton);
            this.hideButton(EZGUI.components.storeButton);
            this.hideButton(EZGUI.components.leaderboardButton);
            this.hideButton(EZGUI.components.profileButton);

            this.showContainer(container);

            if (this.overlay) {
                this.overlay.destroy();
            }

            this.initializeOverlay();

            this.overlay.events.onInputDown.addOnce(function() {
                that.hideContainer(container);
                that.showUI();
            });
        }

        private showButton(button: any): void {
            button.visible = true;
            SiegeGame.game.add.tween(button)
                .to({ alpha: 1 }, Phaser.Timer.SECOND / 4, Phaser.Easing.Linear.None, true, 0);
        }

        private hideButton(button: any): void {
            SiegeGame.game.add.tween(button)
                .to({ alpha: 0 }, Phaser.Timer.SECOND / 4, Phaser.Easing.Linear.None, true, 0)
                .onComplete.addOnce(function() {
                    button.visible = false;
                });
        }

        private showContainer(container: any): void {
            container.visible = true;
            SiegeGame.game.add.tween(container)
                .to({ alpha: 1 }, Phaser.Timer.SECOND / 4, Phaser.Easing.Linear.None, true, 0);
        }

        private hideContainer(container: any): void {
            SiegeGame.game.add.tween(container)
                .to({ alpha: 0 }, Phaser.Timer.SECOND / 4, Phaser.Easing.Linear.None, true, 0)
                .onComplete.addOnce(function() {
                    container.visible = false;
                });
        }

        private initializeOverlay(): void {
            var that = this;

            var overlayGraphic = new Phaser.Graphics(SiegeGame.game, 0, 0);
            overlayGraphic.beginFill(0x000000, 1);
            overlayGraphic.drawRect(0, 0, SiegeGame.game.width, SiegeGame.game.height);
            overlayGraphic.endFill();

            this.overlay = SiegeGame.game.add.image(0, 0, overlayGraphic.generateTexture());
            this.overlay.inputEnabled = true;
            this.overlay.alpha = 0;
            SiegeGame.game.add.tween(that.overlay)
                .to({ alpha: 0.4 }, Phaser.Timer.SECOND / 4, Phaser.Easing.Linear.None, true, 0)
        }
    }
}


