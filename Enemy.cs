using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal abstract class Enemy
    {
        private sbyte attack = 0;
        private sbyte health = 0;
        private sbyte defense = 0;
        private string type = "";

        public string Type 
        {
            get { return type; }
            set { type = value; }
        }

        public sbyte Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public sbyte Health
        {
            get {
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
            set { defense = value; }
        }

        public virtual void DealDamage(Player player, float damageAmount)
        {
            player.Health -= (sbyte)damageAmount;
        }
        public virtual void TakeDamage(float damageAmount)
        {
            Health -= (sbyte)damageAmount;
        }
    }
}
