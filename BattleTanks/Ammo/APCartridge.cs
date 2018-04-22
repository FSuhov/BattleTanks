using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    //класс бронебойного снаряда
    //самое низкое заброневое воздействие
    public class APCartridge : Ammo
    {      
        public APCartridge(Gun someGun) : base(someGun, "подкалиберный") {  }

        public override int GetDamage()
        {
            Console.WriteLine($"Пробивший броню снаряд имеет тип" + this.type + ". Нанесенный урон = " + (int)(base.GetDamage() * Config._APDamage));
            return (int)(base.GetDamage() * Config._APDamage);
        }
    }
}