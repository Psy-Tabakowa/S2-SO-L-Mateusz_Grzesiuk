using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class PositionComparer : IComparer<Request>
    {
        public int Compare(Request request1, Request request2)
        {
            return request1.Position.CompareTo(request2.Position);
        }
    }
}
