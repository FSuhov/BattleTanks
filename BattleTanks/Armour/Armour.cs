using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    public abstract class Armour
    {
        public int thickness;
        public string type;

        public Armour(int thickness, string type)
        {
            this.thickness = thickness;
            this.type = type;
        }

        public virtual bool IsPenetrated(Ammo projectile)
        {
            return projectile.GetDamage() > thickness;
        }
    }
}