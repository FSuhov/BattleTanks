using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    public abstract class Ammo : ICloneable
    {
        Gun gun;
        public string type;
        public Ammo(Gun someGun, string type)
        {
            gun = someGun;
            this.type = type;
        }

        //заброневое воздействие снаряда: сколько здоровья будет снято с танка, если броня будет пробита
        //в базовом классе равна тройному калибру 
        public virtual int GetDamage()
        {
            //TO OVERRIDE: add logic of variable damage depending on Ammo type
            return gun.GetCaliber()*Config._defaultDamage;
        }

        //способность пробивать броню в мм. В базовом виде зависит от калибра (равна калибру)
        //вариативность обеспечена в зависимости от типа снаряда / типа брони
        public int GetPenetration()
        {
            return gun.GetCaliber();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Снаряд " + type + " к пушке калибра " + gun.GetCaliber();
        }
    }
}