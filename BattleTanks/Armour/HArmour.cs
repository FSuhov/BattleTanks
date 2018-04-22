using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    //класс однородной брони. 
    //Оптимален против фугасного снаряда (HECartridge)
    //Хуже против кумулятивного (HEATCartridge)
    //Еще хуже  - против подкалиберного (APCartridge)
    public class HArmour : Armour
    {
        public HArmour(int thickness) : base(thickness, "гомогенная") { }
        public override bool IsPenetrated(Ammo projectile)
        {
            Console.WriteLine($"Прилетел снаряд " + projectile.type + " калибра " + projectile.GetPenetration());
            if (projectile is HECartridge)
            {
                //Если фугасный, то толщина брони считается больше
                Console.WriteLine($"Броня =" + this.thickness * Config._HArmour_VS_HE + " мм");
                return projectile.GetPenetration() > this.thickness * Config._HArmour_VS_HE;
            }
            else if (projectile is HEATCartridge)
            {
                //Если кумулятивный, то толщина брони нормальная
                Console.WriteLine($"Броня =" + this.thickness * Config._HArmour_VS_HEAT + " мм");
                return projectile.GetPenetration() > this.thickness * Config._HArmour_VS_HEAT;
            }
            else
            {
                //Если подкалиберный, то считаем уменьшаем толщину
                Console.WriteLine($"Броня =" + this.thickness * Config._HArmour_VS_AP + " мм");
                return projectile.GetPenetration() > this.thickness * Config._HArmour_VS_AP;
            }
            //возвращаем результат сравнения способности снаряда к проникновению (всегда равна калибру) со скорректированной толщиной брони
            //если TRUE - броня пробита
        }
    }
}
