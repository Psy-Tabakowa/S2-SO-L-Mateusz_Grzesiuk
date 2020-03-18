using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorProcesora
{
    class Proces: IComparable
    {
        public int ExecutionTime { get; set; }
        public int ArrivalTime { get; set; }
        public double State { get; set; } = 0;
        public int WaitingTime { get; set; }

        public Proces(int ilosc)
        {
            Random rnd = new Random();
            ExecutionTime = rnd.Next(1, ilosc);
            ArrivalTime = rnd.Next(1, ilosc*2);
        }
        
        public int CompareTo(object obj)
        {
            return ArrivalTime.CompareTo(((Proces)obj).ArrivalTime);
        }
    }
}
