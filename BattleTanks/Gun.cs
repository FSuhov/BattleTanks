using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTanks
{
    public class Gun
    {
        private int caliber;
        private int barrelLength;

        public Gun(int cal, int length)
        {
            this.caliber = cal;
            this.barrelLength = length;
        }

        public int GetCaliber()
        {
            return this.caliber;
        }

        public bool IsOnTarget(int dice)
        {
            return (barrelLength + dice) > Config._gunTrashold; 
        }
    }
}