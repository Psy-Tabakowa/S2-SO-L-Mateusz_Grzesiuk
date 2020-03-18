using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    abstract class Algorithm: AlgorithmInterface
    {
        public List<Request> Path { get; set; } = new List<Request>();
        public int PathLength { get; set; } = 0;
        public abstract void Processing(List<Request> Requests, int max);
    }
}
