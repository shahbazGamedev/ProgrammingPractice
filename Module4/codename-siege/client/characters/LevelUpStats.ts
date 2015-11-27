module Siege {
    export class LevelUpStats {
        constructor(health: number, damage: number, velocity: number, goldCost: number, upgradePrice: number) {
            this.health = health;
            this.damage = damage;
            this.velocity = velocity;
            this.goldCost = goldCost;
            this.upgradePrice = upgradePrice;
        }

        public health;
        public damage;
        public velocity;
        public goldCost;
        public upgradePrice;
    }
}