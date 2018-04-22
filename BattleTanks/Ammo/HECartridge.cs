using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    //класс фугасного снаряда. Заброневое действие лучше всех
    public class HECartridge : Ammo
    {        
        public HECartridge(Gun someGun) : base(someGun, "фугасный") { }

        public override int GetDamage()
        {
            Console.WriteLine($"Пробивший броню снаряд имеет тип" + this.type + ". Нанесенный урон = " + (int)(base.GetDamage()*Config._HEDamage));
            return (int)(base.GetDamage() * Config._HEDamage);            
        }
    }
}