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
            if (this.spawn == false)
            {
                Random random = new Random();

                this.defaultAttack = (sbyte)random.Next(10, 16);
                this.defaultHealth = (sbyte)random.Next(15, 20);
                this.defaultDefense = (sbyte)random.Next(2, 6);

                this.spawn = true;
            }

            this.Attack = this.defaultAttack;
            this.Health = this.defaultHealth;
            this.Defense = this.defaultDefense;
        }

        public void DealDamage(Enemy enemy, float damageAmount)
        {
            Console.WriteLine($"Player turn!");

            enemy.TakeDamage(damageAmount);
        }

        public void TakeDamage(Enemy enemy, float damageAmount)
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

            this.Health = defaultHealth;

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

        private sbyte attack = 0;
        private sbyte health = 0;
        private sbyte defense = 0;

        private sbyte defaultAttack = 0;
        private sbyte defaultHealth = 0;
        private sbyte defaultDefense = 0;

        private bool spawn = false;

        public sbyte Attack
        {
            get { return attack; }
            private set { attack = value; }
        }
        public sbyte Health
        {
            get
            {
                if (this.health <= 0)
                {
                    return 0;
                }
                return health;
            }
            set { health = value; }
        }

        public sbyte Defense
        {
            get { return defense; }
            private set { defense = value; }
        }
    }
}