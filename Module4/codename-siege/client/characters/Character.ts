/// <reference path="../../lib/definitions/phaser.d.ts"/>
/// <reference path="../SiegeGame.ts"/>
/// <reference path="./Action.ts"/>
/// <reference path="./CharacterType.ts"/>
/// <reference path="./EagleWarrior.ts"/>
/// <reference path="./FirePig.ts"/>
/// <reference path="./GreyDemon.ts"/>
/// <reference path="./HeadCrusher.ts"/>
/// <reference path="./HellTurtle.ts"/>
/// <reference path="./HyenaFighter.ts"/>
/// <reference path="./KarateCat.ts"/>
/// <reference path="./RedDemon.ts"/>
/// <reference path="./SpectralLion.ts"/>
/// <reference path="./SteelPig.ts"/>
/// <reference path="./StoneGiant.ts"/>
/// <reference path="./Vulture.ts"/>
/// <reference path="./LevelUpStats.ts"/>
/// <reference path="./AnimationResetStats.ts"/>

module Siege {
    export class Character {
        constructor(leftSpawnX: number, rightSpawnX: number, player: Player) {
            this.canHitBase = true;
            this.canHitCharacter = true;
            this.timesHit = 0;
            this.animationResetPoints = [];
            this.levelStats = [];

            this.initializeStats();
            
            this.initializeSprite(leftSpawnX, rightSpawnX, player);

            this.currentActionState = Action.Move;
        }

        public sprite: Phaser.Sprite;
        public assetName: string;
        public currentActionState: Action;
        public health: number;
        public damage: number;
        public goldCost: number;
        public attackSpeed: number;
        public velocity: number;
        public upgradePrice: number;

        protected spawnY: number;
        protected scale: number;
        // resets the sprite (if needed) on animation change
        protected animationResetPoints: Array<AnimationResetStats>;
        // incrementing values on character level up
        protected levelStats: Array<LevelUpStats>;

        private player: Player;
        private position: Position;
        private canHitBase: boolean;
        private canHitCharacter: boolean;
        private timesHit: number;

        public static getCharacterFromType(characterType: CharacterType, player: Player): Character {
            var character: Character = null;

            switch (characterType) {
                case CharacterType.EagleWarrior:
                    character = new EagleWarrior(player);
                    break;
                case CharacterType.GreyDemon:
                    character = new GreyDemon(player);
                    break;
                case CharacterType.HeadCrusher:
                    character = new HeadCrusher(player);
                    break;
                case CharacterType.RedDemon:
                    character = new RedDemon(player);
                    break;
                case CharacterType.SpectralLion:
                    character = new SpectralLion(player);
                    break;
                case CharacterType.FirePig:
                    character = new FirePig(player);
                    break;
                case CharacterType.SteelPig:
                    character = new SteelPig(player);
                    break;
                case CharacterType.HellTurtle:
                    character = new HellTurtle(player);
                    break;
                case CharacterType.HyenaFighter:
                    character = new HyenaFighter(player);
                    break;
                case CharacterType.KarateCat:
                    character = new KarateCat(player);
                    break;
                case CharacterType.StoneGiant:
                    character = new StoneGiant(player);
                    break;
                case CharacterType.Vulture:
                    character = new Vulture(player);
                    break;
            }

            return character;
        }

        public static createEnemy(characterType: CharacterType, player: Player, level: number): void {
            var character = Character.getCharacterFromType(characterType, player);
            character.setLevelStats(level);

            SiegeGame.game.physics.arcade.enableBody(character.sprite);
            player.characters.push(character);
        }

        public static create(characterType: CharacterType, player: Player, level: number): void {
            var character = Character.getCharacterFromType(characterType, player);
            character.setLevelStats(level);

            if (player.gold >= character.goldCost) {
                SiegeGame.game.physics.arcade.enableBody(character.sprite);

                player.characters.push(character);
                player.takeGold(character.goldCost);

                SiegeGame.socket.emit('enemy-character-created', {
                    id: player.enemyPlayer.id,
                    characterType: characterType,
                    level: level
                });
                var charSound = SiegeGame.game.add.audio('character-create', 1, false);
                charSound.play();
            }
        }


        public playCurrentState(): void {
            var animationName: string;

            switch (this.currentActionState) {
                case Action.Stand:
                    animationName = 'stand';
                    break;
                case Action.Move:
                    animationName = 'move';
                    this.move();
                    break;
                case Action.Attack:
                    animationName = 'attack';
                    break;
                case Action.Hit:
                    animationName = 'hit';
                    break;
                case Action.Die:
                    animationName = 'die';
                    this.die();
                    break;
            }

            if (this.sprite.animations.currentAnim && this.sprite.animations.currentAnim.name != animationName) {
                this.animationResetPoints.forEach(function(animation) {
                    if (animation.name == animationName) {
                        this.sprite.x += this.position == Position.Left ? animation.x : -animation.x;
                        this.sprite.y = this.spawnY + animation.y;
                    }
                },this);
                
                this.sprite.animations.play(animationName);
            }
        }

        public attackBase(base: Base): void {
            if (this.canHitBase) {

                base.takeDamage(this.damage);
                this.canHitBase = false;

                SiegeGame.game.time.events.add(this.attackSpeed, function() {
                    this.canHitBase = true;
                }, this);
            }
        }

        public attackCharacter(enemyCharacter: Character): void {
            if (this.canHitCharacter) {
                enemyCharacter.takeDamage(this.damage);
                this.canHitCharacter = false;

                SiegeGame.game.time.events.add(this.attackSpeed, function() {
                    this.canHitCharacter = true;
                }, this);
            }
        }

        public setLevelStats(level: number): void {
            this.health = this.levelStats[level - 1].health;
            this.damage = this.levelStats[level - 1].damage;
            this.velocity = this.levelStats[level - 1].velocity;
            this.goldCost = this.levelStats[level - 1].goldCost;
            this.upgradePrice = this.levelStats[level - 1].upgradePrice;
        }

        protected addAnimation(animationName: string, lastFrame: number, frameRate: number): void {
            this.sprite.animations
                .add(animationName, Phaser.Animation.generateFrameNames(animationName, 0, lastFrame, '', 3), frameRate, true);

            if (animationName == 'attack') {
                this.attackSpeed = (lastFrame + 1) * (Phaser.Timer.SECOND / 15);
            }
        }

        private initializeStats(): void {
            // set initial values to all primary stats in order to create the sprite safely
            this.damage = 1;
            this.health = 1;
            this.velocity = 1;
            this.attackSpeed = 1;
            this.goldCost = 1;
        }

        private initializeSprite(leftSpawnX: number, rightSpawnX: number, player: Player): void {
            this.sprite = SiegeGame.game.add.sprite(0, this.spawnY, this.assetName, 'stand000');
            this.sprite.anchor.set(0.5);
            this.sprite.scale.set(this.scale);
            this.sprite.alpha = 0;

            this.player = player;
            this.position = this.player.position;
            if (this.position == Position.Left) {
                this.sprite.scale.x *= -1;
                this.sprite.x = leftSpawnX;
            } else {
                this.sprite.x = rightSpawnX;
            }

            SiegeGame.game.add.tween(this.sprite)
                .to({ alpha: 1 }, Phaser.Timer.SECOND / 2, Phaser.Easing.Linear.None, true, 0);
        }


        private move(): void {
            if (this.position == Position.Left) {
                this.sprite.x += this.velocity;
            } else {
                this.sprite.x -= this.velocity;
            }
        }

        private takeDamage(damage: number) {
            this.health -= damage;

            // this.timesHit++;
            // if (this.timesHit == 3) {
            //     this.timesHit = 0;
            //
            //     this.currentActionState = Action.Hit;
            //
            //     var deltaX = this.position == Position.Left ? -30 : 30;
            //     SiegeGame.game.add.tween(this.sprite)
            //         .to({ x: this.sprite.x + deltaX }, Phaser.Timer.SECOND, Phaser.Easing.Bounce.In, true, 0)
            // }
        }

        private die() {
            if (this.sprite.animations.currentAnim.name == 'die') {
                this.sprite.animations.currentAnim.onLoop.add(function() {
                    this.sprite.kill();
                }, this);
            }
        }

    }
}