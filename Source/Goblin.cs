using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace App1.Source
{
    internal class Goblin : IEnemy
    {
        // Constructor
        public Goblin()
        {
            if (_spawn == false)
            {
                Random random = new Random();

                _defaultAttack = (sbyte)random.Next(10, 16);
                _defaultHealth = (sbyte)random.Next(13, 17);
                _defaultDefense = (sbyte)random.Next(2, 6);

                _spawn = true;
            }

            Attack = _defaultAttack;
            Health = _defaultHealth;
            Defense = _defaultDefense;
            Type = "Goblin";
        }

        public void DealDamage(Player player, float damageAmount)
        {
            Console.WriteLine($"Goblin turn!");

            player.TakeDamage(this, damageAmount);
        }

        public void TakeDamage(float damageAmount)
        {
            Health -= (sbyte)Math.Max(damageAmount - Defense, 0);

            Console.WriteLine($"Goblin took: {{{damageAmount}}} damage from player. Current health: {{{Health}}}. Current Defense: {{{Defense}}}");
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
                if (_health <= 0)
                {
                    return 0;
                }

                return _health;
            }
            set { _health = value; }
        }
        public sbyte Defense { get; set; }
        public string Type { get; set; }
    }
}
