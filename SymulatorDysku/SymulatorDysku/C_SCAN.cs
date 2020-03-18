using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class C_SCAN : Algorithm
    {
        int position, real, max;
        public override void Processing(List<Request> requests, int max)
        {
            this.max = max;
            position = (int)Math.Round((double)max / 2);
            Console.WriteLine("Natychmiastowe(1) czy Real Time(2): ");
            real = int.Parse(Console.ReadLine());
            switch (real)
            {
                case 1:
                    NonRealTime(requests);
                    break;
                case 2:
                    RealTime(requests);
                    break;
                default:
                    break;
            }
        }
        private void NonRealTime(List<Request> requests)
        {
            requests.Sort(new PositionComparer());
            Path = requests;
            for(int i=0; i<requests.Count; i++)
            {
                PathLength=PathLength+requests[i].Position;
            }
        }
        private void RealTime(List<Request> requests)
        {
            List<Request> queue = new List<Request>();
            position = 1;
            bool repeat;
            for (int y = 0; ; y++)
            {
                if (requests.Count == 0 && queue.Count == 0)
                {
                    break;
                }
                if (requests.Count != 0)
                {
                    do
                    {
                        repeat = false;
                        if (y == requests.First().EntryTime)
                        {
                            queue.Add(requests.First());
                            requests.Remove(requests.First());
                            queue.Sort(new PositionComparer());
                            repeat = true;
                            if (requests.Count == 0)
                            {
                                break;
                            }
                        }
                    } while (repeat);
                }
                if (queue.Count != 0)
                {
                    int added = 0;
                    for (int j = 0; j < queue.Count; j++)
                    {
                        if (position == queue[j - added].Position)
                        {
                            Path.Add(queue[j - added]);
                            queue.Remove(queue[j - added]);
                            added++;
                        }
                    }
                    if(added>0)
                    {
                        position = 0;
                    }
                }
                position++;
                PathLength++;
                if(position>max)
                {
                    position = 1;
                }
            }
        }
    }
}
