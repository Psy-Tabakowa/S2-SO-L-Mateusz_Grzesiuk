using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class FCFS: Algorithm
    {
        public override void Processing(List<Request> requests, int max)
        {
            PathLength = PathLength + Math.Abs((int)Math.Round((double)max/2) - requests[0].Position);
            for (int i = 1; i<requests.Count; i++)
            {
                PathLength = PathLength + Math.Abs(requests[i].Position - requests[i - 1].Position);
            }
            Path = requests;
        }
    }
}
