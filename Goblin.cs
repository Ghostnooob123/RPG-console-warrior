using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Goblin : IEnemy
    {
        // Constructor
        public Goblin() {
            if (this._spawn == false)
            {
                Random random = new Random();

                this._defaultAttack = (sbyte)random.Next(10, 16);
                this._defaultHealth = (sbyte)random.Next(13, 17);
                this._defaultDefense = (sbyte)random.Next(2, 6);

                this._spawn = true;
            }

            this.Attack = _defaultAttack;
            this.Health = _defaultHealth;
            this.Defense = _defaultDefense;
            this.Type = "Goblin";
        }

        public void DealDamage(Player player, float damageAmount)
        {
            Console.WriteLine($"Goblin turn!");

            player.TakeDamage(this, damageAmount);
        }

        public void TakeDamage(float damageAmount)                                          
        {
            this.Health -= (sbyte) Math.Max(damageAmount - this.Defense, 0);

            Console.WriteLine($"Goblin took: {{{damageAmount}}} damage from player. Current health: {{{this.Health}}}. Current Defense: {{{this.Defense}}}");
        }

        private sbyte _health = 0;

        private sbyte _defaultAttack = 0;
        private sbyte _defaultHealth = 0;
        private sbyte _defaultDefense = 0;

        private bool _spawn = false;

        public sbyte Attack { get; set; }
        public sbyte Health
        {
            get
            {
                if (this._health <= 0)
                {
                    return 0;
                }

                return this._health;
            }
            set { this._health = value; }
        }
        public sbyte Defense { get; set; }
        public string Type { get; set; }
    }
}
