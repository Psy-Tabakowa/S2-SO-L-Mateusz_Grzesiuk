using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace SymulatorProcesora
{
    class Seria
    {
        internal List<Proces> List { get; set; } = new List<Proces>();
        public Seria(int ilosc)
        {
            for(int i=0; i<ilosc; i++)
            {
                List.Add(new Proces(ilosc));
                Thread.Sleep(20);
            }
            List.Sort();
        }
    }
}
