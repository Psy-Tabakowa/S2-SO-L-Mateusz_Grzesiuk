using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class SSTF : Algorithm
    {
        int position, real;
        public override void Processing(List<Request> requests, int max)
        {
            position = (int)Math.Round((double)max / 2);
            Console.WriteLine("Natychmiastowe(1) czy Real Time(2): ");
            real = int.Parse(Console.ReadLine());
            switch(real)
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
            Request element;
            int stop = requests.Count;
            for (int i = 0; i<stop; i++)
            {
                int length = Math.Abs(position - requests[0].Position);
                element = requests[0];
                for (int j = 1; j < requests.Count; j++)
                {   
                    if(length>Math.Abs(position-requests[j].Position))
                    {
                        length = Math.Abs(position - requests[j].Position);
                        element = requests[j];
                    }
                }
                position = element.Position;
                Path.Add(element);
                PathLength = PathLength + length;
                requests.Remove(element);
            }
        }
        private void RealTime(List<Request> requests)
        {
            List<Request> queue=new List<Request>();
            int waitingTime=0;
            bool repeat;
            for (int y=0; ;y++)
            {
                if (requests.Count == 0 && queue.Count == 0)
                {
                    break;
                }
                if(requests.Count != 0)
                { 
                    do
                    {
                        repeat = false;
                        if(y==requests.First().EntryTime)
                        {
                            queue.Add(requests.First());
                            requests.Remove(requests.First());
                            repeat = true;
                            if (requests.Count == 0)
                            {
                                break;
                            }
                        }
                    } while (repeat);
                }
                
                
                if(waitingTime==0 && queue.Count!=0)
                {
                    int length = Math.Abs(position - queue[0].Position);
                    Request element = queue[0];
                    for (int j = 1; j < queue.Count; j++)
                    {
                        if (length > Math.Abs(position - queue[j].Position))
                        {
                            length = Math.Abs(position - queue[j].Position);
                            element = queue[j];
                        }
                    }
                    Path.Add(element);
                    position = element.Position;
                    PathLength = PathLength + length;
                    queue.Remove(element);
                    waitingTime = length;
                }
                if(waitingTime>0)
                {
                    waitingTime--;
                }
            }
        }
    }
}
