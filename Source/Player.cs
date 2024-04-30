using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace App1.Source
{

    internal class Player
    {
        // Constructor
        public Player()
        {
            if (_spawn == false)
            {
                Random random = new Random();

                _defaultAttack = (sbyte)random.Next(10, 16);
                _defaultHealth = (sbyte)random.Next(15, 20);
                _defaultDefense = (sbyte)random.Next(2, 6);

                _spawn = true;
            }

            Attack = _defaultAttack;
            Health = _defaultHealth;
            Defense = _defaultDefense;
        }

        public static void DealDamage(IEnemy enemy, float damageAmount)
        {
            Console.WriteLine($"Player turn!");

            enemy.TakeDamage(damageAmount);
        }

        public void TakeDamage(IEnemy enemy, float damageAmount)
        {
            Health -= (sbyte)Math.Max(damageAmount - Defense, 0);

            Console.WriteLine($"Player took: {{{damageAmount}}} damage from {{{enemy.Type}}}. Current health: {{{Health}}}. Current Defense: {{{Defense}}}");
        }

        public void PlayerUpgrade(Random random)
        {
            int upgradeAttack = random.Next(1, 5);
            int upgradeHealth = random.Next(1, 5);
            int upgradeDefense = random.Next(1, 5);

            Console.WriteLine($"Choose a upgrade: \n1. Attack {{+{upgradeAttack}}}\n2. Health {{+{upgradeHealth}}}\n3. Defense {{+{upgradeDefense}}}\n");

            Console.Write("Type here: ");
            int input = int.Parse(Console.ReadLine());

            Console.Clear();

            Health = _defaultHealth;

            switch (input)
            {
                case 1:
                    Attack += (sbyte)upgradeAttack;
                    break;
                case 2:
                    Health += (sbyte)upgradeHealth;
                    break;
                case 3:
                    Defense += (sbyte)upgradeDefense;
                    break;
            }
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
    }
}