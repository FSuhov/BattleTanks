using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    public class Panzer
    {
        private string model;
        private Gun gun;
        private List<Armour> armours;
        private List<Ammo> ammos;        
        private int health;
                
        public Ammo LoadedAmmo { get; set; }
        public Armour SelectedArmour { get; set; }

        

        public Panzer(string name, Gun someGun, int armourWidth, int h)
        {
            model = name;
            gun = someGun;
            health = h;
            armours = new List<Armour>();
            ammos = new List<Ammo>();
            AddArmours(armourWidth);
            LoadAmmos();
            LoadedAmmo = null;
            SelectedArmour = armours[0]; //по умолчанию - гомогенная броня
        }
        

        public void LoadGun(string type)
        {
            for(int i = 0; i < ammos.Count; i++)
            {
                if(ammos[i].type == type)
                {
                    LoadedAmmo = ammos[i];
                    Console.WriteLine("заряжено!");
                    return;
                }
            }
            Console.WriteLine($"сорян, командир, " + type + " закончились!");
        }

        public void SelectArmour(string type)
        {
            for (int i = 0; i < armours.Count; i++)
            {
                if (armours[i].type == type)
                {
                    SelectedArmour = armours[i];
                    break;
                }
            }
        }

        public Ammo Shoot()
        {
            if (LoadedAmmo != null)
            {                
                Console.Write($"Танк " + this.model + "выстрелил " + LoadedAmmo.type + " снаряд......");
                Ammo firedAmmo = (Ammo)LoadedAmmo.Clone();
                ammos.Remove(LoadedAmmo);
                LoadedAmmo = null;
                Random rnd = new Random();
                int dice = rnd.Next(0, 100);
                bool hit = this.gun.IsOnTarget(dice);
                if (this.gun.IsOnTarget(dice))
                {
                    Console.WriteLine("Попадание!");
                    return firedAmmo;
                }
                else
                {
                    Console.WriteLine("Промах!");
                    return null;
                }
                
            }
            else Console.WriteLine("не заряжено");
            return null;
        }

        public void HandleHit(Ammo projectile)
        {
            if (SelectedArmour.IsPenetrated(projectile))
            {
                this.health -= projectile.GetDamage();                
            }
            else Console.WriteLine("Броня не пробита.");
        }        

        private void AddArmours(int armourWidth)
        {
            armours.Add(new SArmour(armourWidth)); 
            armours.Add(new HArmour(armourWidth));
            armours.Add(new CArmour(armourWidth));
        }

        private void LoadAmmos()
        {
            for(int i = 0; i < 10; i++)
            {
                ammos.Add(new APCartridge(this.gun));
                ammos.Add(new HEATCartridge(this.gun));
                ammos.Add(new HECartridge(this.gun));
            }
        }

        public int GetHealth()
        {
            return this.health;
        }

        public override string ToString()
        {
            return
                $"Танк " + model + "\n" + "Здоровье текущщее = " + health + 
                ";\n" + "Заряженный снаряд: " + LoadedAmmo.type + "; Выбранная броня: " + SelectedArmour.type + ".\n"; 
        }
    }


}