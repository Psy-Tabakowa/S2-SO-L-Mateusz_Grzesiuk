using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SymulatorProcesora
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount, series, algorithm;
            Seria[] ser;
            CPU_FCFS fcfs = new CPU_FCFS();
            CPU_SJF sjf = new CPU_SJF();
            CPU_SJF_W sjf_w = new CPU_SJF_W();
            CPU_RR rr = new CPU_RR();
            while (true)
            {
                Console.WriteLine("Podaj ilosc procesow: ");
                amount = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj ilosc serii: ");
                series = int.Parse(Console.ReadLine());
                if(amount==0 || series==0)
                {
                    break;
                }
                ser = new Seria[series];
                for(int i = 0; i<series; i++)
                {
                    ser[i] = new Seria(amount);
                    Console.WriteLine("Seria "+i+":\n");
                    foreach(Proces proces in ser[i].List)
                    {
                        Console.Write("["+proces.ArrivalTime+","+proces.ExecutionTime+"] ");
                    }
                    Console.Write("\n");
                }

                bool work = true;
                while(work)
                {
                    Console.WriteLine("Wybierz algorytm:\n1. FCFS\n2. SJF\n3. SJF z wywłaszczeniem\n4. Rotacyjny");
                    algorithm = int.Parse(Console.ReadLine());
                    switch (algorithm)
                    {
                        case 1:
                            double srednia1 = 0;
                            for (int i = 0; i < series; i++)
                            {
                                Seria seri = new Seria(amount);
                                for(int j = 0; j<amount; j++)
                                {
                                    seri.List[j].ArrivalTime = ser[i].List[j].ArrivalTime;
                                    seri.List[j].ExecutionTime = ser[i].List[j].ExecutionTime;
                                }
                                double srednia = fcfs.Execute(seri);
                                srednia1 += srednia;
                                Console.WriteLine("Sredni czas oczekiwania dla serii " + i + ", dla FCFS: " + srednia);
                            }
                            Console.WriteLine("Sredni czas dla FCFS: " + (srednia1 / series));

                            break;
                        case 2:
                            double srednia2 = 0;
                            for (int i = 0; i < series; i++)
                            {
                                Seria seri = new Seria(amount);
                                for (int j = 0; j < amount; j++)
                                {
                                    seri.List[j].ArrivalTime = ser[i].List[j].ArrivalTime;
                                    seri.List[j].ExecutionTime = ser[i].List[j].ExecutionTime;
                                }
                                double srednia = sjf.Execute(seri);
                                srednia2 += srednia;
                                Console.WriteLine("Sredni czas oczekiwania dla serii " + i + ", dla SJF: " + srednia);
                            }
                            Console.WriteLine("Sredni czas dla SJF: " + (srednia2 / series));
                            break;
                        case 3:
                            double srednia3 = 0;
                            for (int i = 0; i < series; i++)
                            {
                                Seria seri = new Seria(amount);
                                for (int j = 0; j < amount; j++)
                                {
                                    seri.List[j].ArrivalTime = ser[i].List[j].ArrivalTime;
                                    seri.List[j].ExecutionTime = ser[i].List[j].ExecutionTime;
                                }
                                double srednia = sjf_w.Execute(seri);
                                srednia3 += srednia;
                                Console.WriteLine("Sredni czas oczekiwania dla serii " + i + ", dla SJF z wywłaszczeniem: " + srednia);
                            }
                            Console.WriteLine("Sredni czas dla SJF_W: " + (srednia3 / series));
                            break;
                        case 4:
                            double srednia4=0;
                            for (int i = 0; i < series; i++)
                            {
                                Seria seri = new Seria(amount);
                                for (int j = 0; j < amount; j++)
                                {
                                    seri.List[j].ArrivalTime = ser[i].List[j].ArrivalTime;
                                    seri.List[j].ExecutionTime = ser[i].List[j].ExecutionTime;
                                }
                                double srednia = rr.Execute(seri);
                                srednia4 += srednia;
                                Console.WriteLine("Sredni czas oczekiwania dla serii "+i+", dla RR: " + srednia);
                            }
                            Console.WriteLine("Sredni czas dla RR: " + (srednia4/ series));
                            break;
                        default:
                            work = false;
                           break;
                    }
                }    
            }
            
            Console.ReadKey();
        }
    }
}
