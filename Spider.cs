using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Spider : Enemy
    {
        // Constructor
        public Spider() {
            if (this.spawn == false)
            {
                Random random = new Random();

                this.defaultAttack = (sbyte)random.Next(11, 20);
                this.defaultHealth = (sbyte)random.Next(15, 26);
                this.defaultDefense = (sbyte)random.Next(2, 6);

                this.spawn = true;
            }

            this.Attack = defaultAttack;
            this.Health = defaultHealth;
            this.Defense = defaultDefense;
            this.Type = "Spider";
        }

        public override void DealDamage(Player player, float damageAmount)
        {
            Console.WriteLine($"Spider turn!");

            player.TakeDamage(this, damageAmount);
        }

        public override void TakeDamage(float damageAmount)
        {
            this.Health -= (sbyte) Math.Max(damageAmount - this.Defense, 0); ;

            Console.WriteLine($"Spider took: {{{damageAmount}}} damage from player. Current health: {{{this.Health}}}. Current Defense: {{{this.Defense}}}");
        }

        private sbyte defaultAttack = 0;
        private sbyte defaultHealth = 0;
        private sbyte defaultDefense = 0;

        private bool spawn = false;
    }
}
