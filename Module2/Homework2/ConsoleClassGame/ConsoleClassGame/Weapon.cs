namespace ConsoleClassGame
{
    using System;
    
    class Weapon
    {
        private enum WeaponType { Sword, Hammer, Dagger };
        private enum WeaponClass { Common, Rare, Mythical };

        protected int damage;
        
        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
            }
        }
        
    }
}
