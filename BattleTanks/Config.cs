using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTanks
{
    public static class Config
    {
        public static List<string> ammoTypes = new List<string> { "фугасный", "кумулятивный", "подкалиберный" };
        public static List<string> armourTypes = new List<string> { "гомогенная", "разнесенная", "комбинированная" };

        //трешхолд для пушки - величина, выше которой будем считать, что снаряд попал в цель
        public static int _gunTrashold = 100;

        //дефолтный коэфициент для заброневого действия базового снаряда
        public static int _defaultDamage = 3;

        //коэффициенты урона для снарядов разных типов
        public static double _HEDamage = 1.0;
        public static double _HEATDamage = 0.6;
        public static double _APDamage = 0.3;

        //коэффициенты стойкости брони
        //для гомогенной:
        //Если в гомогенную броню прилетает фугасный, то ее толщина считается большей -  коефициент 1.2
        public static double _HArmour_VS_HE = 1.2;
        //Если в гомогенную броню прилетает кумулятивный, то ее толщина считается нормальной -  коефициент 1.0
        public static double _HArmour_VS_HEAT = 1.0;
        //Если в гомогенную броню прилетает подкалиберный, то ее толщина считается меньшей -  коефициент 0.7
        public static double _HArmour_VS_AP = 0.7;

        //для комбинированной брони
        //Если в комбинированную броню прилетает фугасный, то ее толщина считается нормальной -  коефициент 1
        public static double _СArmour_VS_HE = 1.0;
        //Если в комбинированную броню прилетает фугасный, то ее толщина считается меньше - коэфициент 0.8
        public static double _СArmour_VS_HEAT = 0.8;
        //Если в комбинированную броню прилетает фугасный, то ее толщина считается больше - коэфициент 1.2
        public static double _СArmour_VS_AP = 1.2;

        //Для разнесенной брони
        //Если в разнесенную броню прилетает фугасный, то ее толщина считается меньше - коэфициент 0.8
        public static double _SArmour_VS_HE = 0.8;

        //Если в  разнесенную броню прилетает кумулятивный, то ее толщина считается больше - коэфициент 1.2
        public static double _SArmour_VS_HEAT = 1.2;

        //Если в  разнесенную броню прилетает подкалибереый, то ее толщина считается нормальной - коэфициент 1
        public static double _SArmour_VS_AP = 1.0;
    }
}
