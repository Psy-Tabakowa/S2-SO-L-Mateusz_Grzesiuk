using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class Reference
    {
        List<int> intList;
        public int LogicalLocation { get; set; }
        public Reference(int length)
        {
            intList = new List<int>();
            for(int i=0; i<Math.Floor((double)length/10*8); i++)
            {
                intList.Add(i);
            }
            for (int i = (int)Math.Floor((double)length / 10 * 8); i < Math.Floor((double)length / 10 * 9); i++)
            {
                for(int j=0; j<72; j++)
                {
                    intList.Add(i);
                }
            }
            for (int i = (int)Math.Floor((double)length / 10 * 9); i < length; i++)
            {
                for (int j = 0; j <720; j++)
                {
                    intList.Add(i);
                }
            }
            LogicalLocation= intList[new Random().Next(0,intList.Count-1)];
            intList = null;
        }
        public int NewLocation(int lastLocation, int length)
        {
            intList = new List<int>();
            for(int i=0; i<Math.Floor((double)length/10*8); i++)
            {
                intList.Add(i);
            }
            for (int i = (int)Math.Floor((double)length / 10 * 8); i < Math.Floor((double)length / 10 * 9); i++)
            {
                for(int j=0; j<72; j++)
                {
                    intList.Add(i);
                }
            }
            for (int i = (int)Math.Floor((double)length / 10 * 9); i < length; i++)
            {
                for (int j = 0; j <720; j++)
                {
                    intList.Add(i);
                }
            }
            return intList[new Random().Next(0,intList.Count-1)];
        }
    }
}
