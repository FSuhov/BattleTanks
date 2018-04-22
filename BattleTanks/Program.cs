using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTanks
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Panzer player1 = new Panzer("ИС-2", new Gun(122, 40), 90, 600);
            Panzer player2 = new Panzer("Тигр", new Gun(88, 55), 120, 650);

            string selectedStr;
            int selectedAmmo;
            int selectedArmour;

            while(true)
            {
                //================================= ХОД ПЕВРОГО ИГРОКА =========================================
                Console.WriteLine("========== Игрок 1 ============>");
                selectedAmmo = -1;
                while (player1.LoadedAmmo == null)
                {
                    while (selectedAmmo < 0 || selectedAmmo > 2)
                    {
                        Console.WriteLine("Выбрать снаряд:");
                        Console.WriteLine("0 - фугасный");
                        Console.WriteLine("1 - кумулятивный");
                        Console.WriteLine("2 - бронебойный");
                        selectedStr = Console.ReadLine();
                        int.TryParse(selectedStr, out selectedAmmo);
                    }
                    player1.LoadGun(Config.ammoTypes[selectedAmmo]);
                }
                Console.WriteLine();
                selectedArmour = -1;
                while (selectedArmour < 0 || selectedArmour > 2)
                {
                    Console.WriteLine("Выбрать броню:");
                    Console.WriteLine("0 - гомогенная");
                    Console.WriteLine("1 - разнесенная");
                    Console.WriteLine("2 - комбинированная");
                    selectedStr = Console.ReadLine();
                    int.TryParse(selectedStr, out selectedArmour);
                }
                player1.SelectArmour(Config.armourTypes[selectedArmour]);

                Console.WriteLine();
                Console.WriteLine("Игрок 1 - текущее состояние:");
                Console.Write(player1.ToString());
                Console.WriteLine("Нажмите ENTER для выстрела");
                Console.ReadKey();

                Ammo flyingAmmo = (Ammo)player1.Shoot()?.Clone();
                if(flyingAmmo!=null)
                {
                    player2.HandleHit(flyingAmmo);
                }
                if(player2.GetHealth()<=0)
                {
                    Console.WriteLine($"Танк игрока 2 уничтожен");
                    break;
                }
                //================================= ХОД ВТОРОГО ИГРОКА =========================================
                Console.WriteLine("========== Игрок 2 ============>");
                selectedAmmo = -1;
                while (player2.LoadedAmmo == null)
                {
                    while (selectedAmmo < 0 || selectedAmmo > 2)
                    {
                        Console.WriteLine("Выбрать снаряд:");
                        Console.WriteLine("0 - фугасный");
                        Console.WriteLine("1 - кумулятивный");
                        Console.WriteLine("2 - бронебойный");
                        selectedStr = Console.ReadLine();
                        int.TryParse(selectedStr, out selectedAmmo);
                    }
                    player2.LoadGun(Config.ammoTypes[selectedAmmo]);
                }

                selectedArmour = -1;
                while (selectedArmour < 0 || selectedArmour > 2)
                {
                    Console.WriteLine("Выбрать броню:");
                    Console.WriteLine("0 - гомогенная");
                    Console.WriteLine("1 - разнесенная");
                    Console.WriteLine("2 - комбинированная");
                    selectedStr = Console.ReadLine();
                    int.TryParse(selectedStr, out selectedArmour);
                }

                player2.SelectArmour(Config.armourTypes[selectedArmour]);


                Console.WriteLine("Игрок 2:");
                Console.Write(player2.ToString());
                Console.WriteLine("Нажмите ENTER для выстрела");
                Console.ReadKey();

                flyingAmmo = (Ammo)player2.Shoot()?.Clone();
                if (flyingAmmo != null)
                {
                    player1.HandleHit(flyingAmmo);
                }
                if (player1.GetHealth() <= 0)
                {
                    Console.WriteLine($"Танк игрока 1 уничтожен");
                    break;
                }
            }
        }
    }
}
