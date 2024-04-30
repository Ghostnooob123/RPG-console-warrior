using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace App1
{

    internal class Player
    {
        // Constructor
        public Player()
        {
            if (this._spawn == false)
            {
                Random random = new Random();

                this._defaultAttack = (sbyte)random.Next(10, 16);
                this._defaultHealth = (sbyte)random.Next(15, 20);
                this._defaultDefense = (sbyte)random.Next(2, 6);

                this._spawn = true;
            }

            this.Attack = this._defaultAttack;
            this.Health = this._defaultHealth;
            this.Defense = this._defaultDefense;
        }

        public static void DealDamage(IEnemy enemy, float damageAmount)
        {
            Console.WriteLine($"Player turn!");

            enemy.TakeDamage(damageAmount);
        }

        public void TakeDamage(IEnemy enemy, float damageAmount)
        {
            this.Health -= (sbyte)Math.Max(damageAmount - this.Defense, 0);

            Console.WriteLine($"Player took: {{{damageAmount}}} damage from {{{enemy.Type}}}. Current health: {{{this.Health}}}. Current Defense: {{{this.Defense}}}");
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

            this.Health = _defaultHealth;

            switch (input)
            {
                case 1:
                    this.Attack += (sbyte)upgradeAttack;
                    break;
                case 2:
                    this.Health += (sbyte)upgradeHealth;
                    break;
                case 3:
                    this.Defense += (sbyte)upgradeDefense;
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
            if (this._health <= 0)
                {
                    return 0;
                }

                return this._health;
            }
            set { this._health = value; }
        }
        public sbyte Defense { get; set; }
    }
}