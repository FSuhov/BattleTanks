using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    //класс разнесенной брони. 
    //Оптимален против кумулятивного снаряда (HEATCartridge)
    //Хуже против подкалиберного (APCartridge)
    //Еще хуже  - против фугасного (HECartridge)
    public class SArmour : Armour
    {
        public SArmour(int thickness) : base(thickness, "разнесенная") { }
        public override bool IsPenetrated(Ammo projectile)
        {
            Console.WriteLine($"Прилетел снаряд " + projectile.type + " калибра " + projectile.GetPenetration());
            if (projectile is HECartridge)
            {
                //Если фугасный, то толщина брони считается меньше
                Console.WriteLine($"Броня =" + this.thickness * Config._SArmour_VS_HE + " мм");
                return projectile.GetPenetration() > this.thickness * Config._SArmour_VS_HE;
            }
            else if (projectile is HEATCartridge)
            {
                //Если кумулятивный, то толщина брони как бы больше
                Console.WriteLine($"Броня =" + this.thickness * Config._SArmour_VS_HEAT + " мм");
                return projectile.GetPenetration() > this.thickness * Config._SArmour_VS_HEAT;
            }
            else
            {
                //Если подкалиберный, то считаем нормальную толщину
                Console.WriteLine($"Броня =" + this.thickness * Config._SArmour_VS_AP + " мм");
                return projectile.GetPenetration() > this.thickness * Config._SArmour_VS_AP;
            }
            //возвращаем результат сравнения способности снаряда к проникновению (всегда равна калибру) со скорректированной толщиной брони
            //если TRUE - броня пробита
        }
    }
}