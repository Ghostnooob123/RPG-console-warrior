using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Source
{
    internal interface IEnemy
    {

        public sbyte Attack { get; set; }
        public sbyte Health { get; set; }
        public sbyte Defense { get; set; }
        public string Type { get; set; }

        public void DealDamage(Player player, float damageAmount);
        public void TakeDamage(float damageAmount);
    }
}
