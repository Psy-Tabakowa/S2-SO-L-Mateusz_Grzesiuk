using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class EDF : Algorithm
    {
        public override void Processing(List<Request> requests, int max)
        {
            List<Request> queue = new List<Request>();
            int position = Math.Abs((int)Math.Round((double)max / 2));
            int waitingTime=0;
            bool repeat;
            for (int y=0; ; y++)
            {
                if (requests.Count == 0 && queue.Count == 0)
                {
                    break;
                }
                if (queue.Count!=0)
                {
                    foreach(Request req in queue)
                    {
                        req.Deadline--;
                    }
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
                if (waitingTime == 0 && queue.Count != 0)
                {
                    Request element = queue[0];
                    int deadline = queue[0].Deadline;
                    for (int j = 1; j < queue.Count; j++)
                    {
                        if (deadline > queue[j].Deadline)
                        {
                            deadline = queue[j].Deadline;
                            element = queue[j];
                        }
                    }
                    Path.Add(element);
                    PathLength = PathLength + Math.Abs(position-element.Position);
                    waitingTime= Math.Abs(position - element.Position);
                    position = element.Position;
                    queue.Remove(element);
                }
                if (waitingTime != 0)
                {
                    waitingTime--;
                }
            }
        }
    }
}
