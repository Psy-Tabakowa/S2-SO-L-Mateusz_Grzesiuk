using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class Generator
    {
        public List<Request> Requests { get; set; } = new List<Request>();
        public void GenerateRequests(int max, int quantity)
        {
            for(int i=0; i< quantity; i++)
            {
                Requests.Add(new Request(max, quantity));
            }
        }
    }
}
