namespace PlazaSmash.Models
{
    using System;
    using Microsoft.Xna.Framework;

    public class FighterModel : ModelObject
    {
        private const int DefaultHealth = 100;

        public FighterModel(string name)
        {
            this.Health = DefaultHealth;

            this.Name = name;

            this.InitializeCharacter(name);

            // REMOVES THE LEGS FOR PRECISE COLLISION
            this.HitBounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, (int)((float)this.Bounds.Width / 2.5f), this.Bounds.Height / 2);

            this.HasBeenHit = false;
        }

        // FOR COLLISION DETECTION:
        public Rectangle HitBounds { get; private set; }

        public bool IsBlocking { get; set; }

        public int Damage { get; set; }

        // TO EVADE TAKING THE FULL DAMGE OF THE ATTACK (ALL ANIMATIONS COMBINED)
        public bool HasBeenHit { get; set; }

        // USE WHEN ADDING MORE FIGHTERS:
        public bool StartsOnTheLeft { get; private set; }

        public int Health { get; set; }

        private int MoveVelocity { get; set; }

        private int PunchVelocity { get; set; }

        private int KickVelocity { get; set; }

        private int GotHitVelocity { get; set; }

        private int BlockHitVelocity { get; set; }

        private int BlockDamageResistance { get; set; }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "right":
                    this.Location = new Vector2(this.Location.X + (float)this.MoveVelocity, this.Location.Y);
                    break;
                case "left":
                    this.Location = new Vector2(this.Location.X - (float)this.MoveVelocity, this.Location.Y);
                    break;
                case "collisionRight":
                    this.Location = new Vector2(this.Location.X - 5, this.Location.Y);
                    break;
                case "collisionLeft":
                    this.Location = new Vector2(this.Location.X + 5, this.Location.Y);
                    break;
            }

            this.ChangeBounds();
        }

        public void Punch()
        {
            this.Location = new Vector2(this.Location.X + (float)this.PunchVelocity, this.Location.Y);

            this.ChangeBounds();
        }

        public void Kick()
        {
            this.Location = new Vector2(this.Location.X + (float)this.KickVelocity, this.Location.Y);

            this.ChangeBounds();
        }

        public void GotHit(int amount)
        {
            if (this.HasBeenHit)
            {
                this.DecreaseHealth(amount);
            }

            this.Location = new Vector2(this.Location.X + (float)this.GotHitVelocity, this.Location.Y);

            this.ChangeBounds();
        }

        public void GotHitOnBlock(int amount)
        {
            if (this.HasBeenHit)
            {
                this.DecreaseHealth(amount - this.BlockDamageResistance);
            }

            this.Location = new Vector2(this.Location.X + (float)this.GotHitVelocity, this.Location.Y);

            this.ChangeBounds();
        }

        public bool IsDead()
        {
            bool isDead = false;

            if (this.Health <= 0)
            {
                isDead = true;
            }

            return isDead;
        }

        // EXTRACT IN ANOTHER CLASS ?
        private void InitializeCharacter(string name)
        {
            switch (name)
            {
                case "Clark":
                    this.Location = new Vector2(110, 230);
                    this.Bounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, 320, 240);
                    this.MoveVelocity = 3;
                    this.PunchVelocity = 10;
                    this.KickVelocity = 5;
                    this.GotHitVelocity = -15;
                    this.BlockHitVelocity = -5;
                    this.BlockDamageResistance = 10;
                    this.Damage = 3;
                    this.StartsOnTheLeft = true;
                    break;
                case "Yuri":
                    this.Location = new Vector2(760, 290);
                    this.Bounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, 240, 180);
                    this.MoveVelocity = 6;
                    this.PunchVelocity = -5;
                    this.KickVelocity = -15;
                    this.GotHitVelocity = 20;
                    this.BlockHitVelocity = 15;
                    this.BlockDamageResistance = 5;
                    this.Damage = 1;
                    this.StartsOnTheLeft = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid character");
            }
        }

        private void ChangeBounds()
        {
            this.Bounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.Bounds.Width, this.Bounds.Height);

            this.HitBounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.HitBounds.Width, this.HitBounds.Height);
        }

        private void DecreaseHealth(int amount)
        {
            if (this.Health <= 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= amount;
            }
        }
    }
}
