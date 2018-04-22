using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    //класс кумулятивного снаряда. Заброневое действие хуже, чем
    //у фугасного, но больше, чем у бронебойного
    public class HEATCartridge : Ammo
    {        
        public HEATCartridge(Gun someGun) : base(someGun, "кумулятивный") { }
        
        public override int GetDamage()
        {
            Console.WriteLine($"Пробивший броню снаряд имеет тип" + this.type + ". Нанесенный урон = " + (int)(base.GetDamage() * Config._HEATDamage));
            return (int)(base.GetDamage() * Config._HEATDamage);
        }
    }
}