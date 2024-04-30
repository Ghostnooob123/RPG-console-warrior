using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Source
{
    internal class Spider : IEnemy
    {
        // Constructor
        public Spider()
        {
            if (_spawn == false)
            {
                Random random = new Random();

                _defaultAttack = (sbyte)random.Next(11, 15);
                _defaultHealth = (sbyte)random.Next(13, 16);
                _defaultDefense = (sbyte)random.Next(1, 4);

                _spawn = true;
            }

            Attack = _defaultAttack;
            Health = _defaultHealth;
            Defense = _defaultDefense;
            Type = "Spider";
        }

        public void DealDamage(Player player, float damageAmount)
        {
            Console.WriteLine($"Spider turn!");

            player.TakeDamage(this, damageAmount);
        }

        public void TakeDamage(float damageAmount)
        {
            Health -= (sbyte)Math.Max(damageAmount - Defense, 0); ;

            Console.WriteLine($"Spider took: {{{damageAmount}}} damage from player. Current health: {{{Health}}}. Current Defense: {{{Defense}}}");
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
