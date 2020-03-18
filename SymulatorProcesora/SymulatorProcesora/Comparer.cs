using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorProcesora
{
    class Comparer: IComparer<Proces>
    {
        public int Compare(Proces proces1, Proces proces2)
        {
            return proces1.ExecutionTime.CompareTo(proces2.ExecutionTime);
        }
    }
}
