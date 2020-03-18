using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    interface AlgorithmInterface
    {
        void Processing(List<Request> Requests, int max);
    }
}
