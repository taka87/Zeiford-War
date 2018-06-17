using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01War
{
    public class Soldier : IComparable<Soldier>
    {
        public int SoldierIndex { get; set; }
        public int MLoad { get; set; }
        public int WFood { get; set; }

        public int CompareTo(Soldier other)
        {

            if (this.MLoad == other.MLoad)
            {
                return this.WFood.CompareTo(other.WFood);
            }
            return other.MLoad.CompareTo(this.MLoad);
        }
    }
}
