namespace ConsoleClassGame
{
    using System;

    class Hero
    {
        protected const int MAX_ATTRIBUTE = 20;

        protected string name;
        protected int health;
        protected int mana;
        protected int level;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid level > 0!");
                }
                this.level = value;
            }
        }

        public bool IsDead()
        {
            bool heroIsDead = false;

            if (this.health <= 0)
            {
                heroIsDead = true;
            }

            return heroIsDead;
        }

        public bool IsBlocking()
        {
            Random rng = new Random();

            bool heroIsBlocking = false;

            if (rng.Next(0, 1) == 1)
            {
                heroIsBlocking = true;
            }

            return heroIsBlocking;
        }
    }

    class Sorcerer : Hero
    {
        private const int MAX_SORCERER_HEALTH = 50;
        private const int MAX_SORCERER_MANA = 100;

        private int intelligence;

        public Sorcerer()
        {
            this.health = MAX_SORCERER_HEALTH;
            this.mana = MAX_SORCERER_MANA;
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                if (value <= 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Enter valid intelligence 1-{0}!", MAX_ATTRIBUTE.ToString());
                }
                this.intelligence = value;
            }
        }
    }

    class Fighter : Hero
    {
        private const int MAX_FIGHTER_HEALTH = 70;
        private const int MAX_FIGHTER_MANA = 50;

        private int agility;

        public Fighter()
        {
            this.health = MAX_FIGHTER_HEALTH;
            this.mana = MAX_FIGHTER_MANA;
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                if (value <= 0 || value > MAX_ATTRIBUTE)
                {
                    throw new ArgumentOutOfRangeException("Enter valid agility 1-{0}!", MAX_ATTRIBUTE.ToString());
                }
                this.agility = value;
            }
        }
    }

    class Tank : Hero
    {
        private const int MAX_TANK_HEALTH = 100;
        private const int MAX_TANK_MANA = 10;

        private int strength;

        public Tank()
        {
            this.health = MAX_TANK_HEALTH;
            this.mana = MAX_TANK_MANA;
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                if (value <= 0 || value > MAX_ATTRIBUTE)
                {
                    throw new ArgumentOutOfRangeException("Enter valid strength 1-{0}!", MAX_ATTRIBUTE.ToString());
                }
                this.strength = value;
            }
        }
    }
}
