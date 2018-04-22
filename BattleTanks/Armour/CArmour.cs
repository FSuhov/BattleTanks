using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    //класс комбинированной брони. 
    //Оптимален против подкалиберного снаряда (APCartridge)
    //Хуже против фугасного (HECartridge)
    //Еще хуже  - против кумулятивного (HEAPCartridge)
    public class CArmour : Armour
    {
        public CArmour(int thickness) : base(thickness, "комбинированная") { }
        public override bool IsPenetrated(Ammo projectile)
        {
            Console.WriteLine($"Прилетел снаряд " + projectile.type + " калибра " + projectile.GetPenetration());
            if (projectile is HECartridge)
            {
                //Если фугасный, то толщина брони считается нормально
                Console.WriteLine($"Броня =" + this.thickness * Config._СArmour_VS_HE + " мм");
                return projectile.GetPenetration() > this.thickness * Config._СArmour_VS_HE;
            }
            else if (projectile is HEATCartridge)
            {
                //Если кумулятивный, то толщина брони как бы меньше
                Console.WriteLine($"Броня =" + this.thickness * Config._СArmour_VS_HEAT + " мм");
                return projectile.GetPenetration() > this.thickness * Config._СArmour_VS_HEAT;
            }
            else
            {
                //Если подкалиберный, то толщина как бы больше
                Console.WriteLine($"Броня =" + this.thickness * Config._СArmour_VS_AP + " мм");
                return projectile.GetPenetration() > this.thickness * Config._СArmour_VS_AP;
            }
            //возвращаем результат сравнения способности снаряда к проникновению (всегда равна калибру) со скорректированной толщиной брони
            //если TRUE - броня пробита
        }
    }
}