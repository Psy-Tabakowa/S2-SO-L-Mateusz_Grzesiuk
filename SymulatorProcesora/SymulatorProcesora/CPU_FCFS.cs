using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorProcesora
{
    class CPU_FCFS: CPU
    {
        
        public double Execute(Seria seria)
        {
            List<Proces> waiting = new List<Proces>();
            List<Proces> executed = new List<Proces>();
            int waitingTime = 0;
            int length = seria.List.Count();
            Proces executing = new Proces(1);
            executing.ExecutionTime--;
            executed.Add(executing);
            int added = 0;
            for (int i=1; executed.Count<=(length+1); i++)
            {
                if(seria.List.Count!=0)
                {
                    do
                    {
                        if(seria.List.Count==0)
                        {
                            break;
                        }
                        if (seria.List.First().ArrivalTime == i)
                        {
                            waiting.Add(seria.List.First());
                            seria.List.Remove(seria.List.First());
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }

                if (executing.ExecutionTime<=0)
                {
                    if(added==0)
                    {
                        executed.Add(executing);
                        added = 1;
                    }
                    if(waiting.Count!=0)
                    {
                        executing = waiting.First();
                        waiting.Remove(waiting.First());
                        added = 0;
                    }
                }

                executing.ExecutionTime--;

                foreach (Proces proces in waiting)
                {
                    proces.WaitingTime++;
                }
            }
            foreach (Proces proces in executed)
            {
                waitingTime+=proces.WaitingTime;
            }

            return (((double)waitingTime) / length);
        }
    }
}
