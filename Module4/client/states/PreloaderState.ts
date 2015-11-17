/// <reference path='../../lib/definitions/phaser.d.ts'/>
/// <reference path='./IntroState.ts'/>
/// <reference path='./MenuState.ts'/>
/// <reference path='./GameState.ts'/>
/// <reference path='./GameOverState.ts'/>
/// <reference path='../SiegeGame.ts'/>

module Siege {
    export class PreloaderState extends Phaser.State {
        public preload(): void {
            // INTRO
            SiegeGame.game.load.image('logo', 'client/assets/intro/logo.png');
            SiegeGame.game.load.image('zariba', 'client/assets/intro/zariba.png');
            SiegeGame.game.load.image('academy', 'client/assets/intro/academy.png');
            SiegeGame.game.load.image('blue', 'client/assets/intro/blue.png');
            SiegeGame.game.load.image('green', 'client/assets/intro/green.png');
            SiegeGame.game.load.image('hat', 'client/assets/intro/hat.png');
            SiegeGame.game.load.image('line', 'client/assets/intro/line.png');

            // MENU
            SiegeGame.game.load.atlasJSONArray('menu',
                'client/assets/menu/menu.png',
                'client/assets/menu/menu.json'
            );

            // MAPS
            SiegeGame.game.load.atlas('grass-field',
                'client/assets/maps/grass-field/grass-field.png',
                'client/assets/maps/grass-field/grass-field.json'
            );

            // BASES
            SiegeGame.game.load.atlas('frozen-cave',
                'client/assets/bases/frozen-cave/frozen-cave.png',
                'client/assets/bases/frozen-cave/frozen-cave.json'
            );

            SiegeGame.game.load.atlas('forest-cave',
                'client/assets/bases/forest-cave/forest-cave.png',
                'client/assets/bases/forest-cave/forest-cave.json'
            );

            //GUI
            SiegeGame.game.load.atlas('GUI', 'client/assets/gui/gui.png',
                'client/assets/gui/gui.json');
                
            // CHARACTERS
            SiegeGame.game.load.atlas('eagle-warrior', 'client/assets/characters/eagle-warrior/eagle-warrior.png',
                'client/assets/characters/eagle-warrior/eagle-warrior.json');
            SiegeGame.game.load.image('eagle-warrior-head', 'client/assets/gui/character-head-icons/eagle-warrior.png');

            SiegeGame.game.load.atlas('fire-pig', 'client/assets/characters/fire-pig/fire-pig.png',
                'client/assets/characters/fire-pig/fire-pig.json');
            SiegeGame.game.load.image('fire-pig-head', 'client/assets/gui/character-head-icons/fire-pig.png');

            SiegeGame.game.load.atlas('grey-demon', 'client/assets/characters/grey-demon/grey-demon.png',
                'client/assets/characters/grey-demon/grey-demon.json');
            SiegeGame.game.load.image('grey-demon-head', 'client/assets/gui/character-head-icons/grey-demon.png');

            SiegeGame.game.load.atlas('head-crusher', 'client/assets/characters/head-crusher/head-crusher.png',
                'client/assets/characters/head-crusher/head-crusher.json');
            SiegeGame.game.load.image('head-crusher-head', 'client/assets/gui/character-head-icons/head-crusher.png');

            SiegeGame.game.load.atlas('red-demon', 'client/assets/characters/red-demon/red-demon.png',
                'client/assets/characters/red-demon/red-demon.json');
            SiegeGame.game.load.image('red-demon-head', 'client/assets/gui/character-head-icons/red-demon.png');

            SiegeGame.game.load.atlas('spectral-lion', 'client/assets/characters/spectral-lion/spectral-lion.png',
                'client/assets/characters/spectral-lion/spectral-lion.json');
            SiegeGame.game.load.image('spectral-lion-head', 'client/assets/gui/character-head-icons/spectral-lion.png');

            SiegeGame.game.load.atlas('hell-turtle', 'client/assets/characters/hell-turtle/hell-turtle.png',
                'client/assets/characters/hell-turtle/hell-turtle.json');
            SiegeGame.game.load.image('hell-turtle-head', 'client/assets/gui/character-head-icons/hell-turtle.png');

            SiegeGame.game.load.atlas('hyena-fighter', 'client/assets/characters/hyena-fighter/hyena-fighter.png',
                'client/assets/characters/hyena-fighter/hyena-fighter.json');
            SiegeGame.game.load.image('hyena-fighter-head', 'client/assets/gui/character-head-icons/hyena-fighter.png');

            SiegeGame.game.load.atlas('karate-cat', 'client/assets/characters/karate-cat/karate-cat.png',
                'client/assets/characters/karate-cat/karate-cat.json');
            SiegeGame.game.load.image('karate-cat-head', 'client/assets/gui/character-head-icons/karate-cat.png');

            SiegeGame.game.load.atlas('steel-pig', 'client/assets/characters/steel-pig/steel-pig.png',
                'client/assets/characters/steel-pig/steel-pig.json');
            SiegeGame.game.load.image('steel-pig-head', 'client/assets/gui/character-head-icons/steel-pig.png');
 
            SiegeGame.game.load.atlas('stone-giant', 'client/assets/characters/stone-giant/stone-giant.png',
                'client/assets/characters/stone-giant/stone-giant.json');
            SiegeGame.game.load.image('stone-giant-head', 'client/assets/gui/character-head-icons/stone-giant.png');

            SiegeGame.game.load.atlas('vulture', 'client/assets/characters/vulture/vulture.png',
                'client/assets/characters/vulture/vulture.json');
            SiegeGame.game.load.image('vulture-head', 'client/assets/gui/character-head-icons/vulture.png');

            //sounds
            SiegeGame.game.load.audio('menu-music',['client/assets/sounds/menu-music.mp3',
                'client/assets/sounds/menu-music.ogg']);
            SiegeGame.game.load.audio('game-music',['client/assets/sounds/game-music.mp3',
                'client/assets/sounds/game-music.ogg']);
            SiegeGame.game.load.audio('button-click',['client/assets/sounds/button-click.mp3',
                'client/assets/sounds/button-click.ogg']);
            SiegeGame.game.load.audio('character-create',['client/assets/sounds/character-create.mp3',
                'client/assets/sounds/character-create.ogg']);
            SiegeGame.game.load.audio('level-up',['client/assets/sounds/level-up.mp3',
                'client/assets/sounds/level-up.ogg']);


            SiegeGame.game.load.onLoadComplete.addOnce(function() {
                this.initStates();
                this.setScale();
                
                SiegeGame.game.state.start('Intro');
            }, this);
        }

        private initStates(): void {
            SiegeGame.game.state.add('Intro', IntroState);
            SiegeGame.game.state.add('Menu', MenuState);
            SiegeGame.game.state.add('Game', GameState);
            SiegeGame.game.state.add('GameOver', GameOverState);
        }

        private setScale(): void {
            SiegeGame.game.scale.scaleMode = Phaser.ScaleManager.NO_SCALE;
        }
    }
}