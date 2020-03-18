using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class Disc
    {
        public List<Request> requests { get; set; } = new List<Request>();
        int choice, max, quantity;
        bool loop = true;
        Algorithm algorithm;
        public List<Request> requestsCopy { get; set; } = new List<Request>();

        public Disc()
        {
            Launch();
        }
        public void Launch()
        {
            Console.WriteLine("Podaj ilosc blokow: ");
            max = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ilosc Rzadan: ");
            quantity = int.Parse(Console.ReadLine());
            GenerateRequests(max, quantity);
            while(loop)
            {
                ChooseAlgorithm();
            }
            
        }
        public void GenerateRequests(int max, int quantity)
        {
            Generator gen = new Generator();
            gen.GenerateRequests(max, quantity);
            requests = gen.Requests;
            requests.Sort();
            Console.WriteLine("Wygenerowe rzadania:");
            for (int i = 0; i < requests.Count; i++)
            {
                Console.Write(" " + requests[i].Position + " |");
            }
        }
        public void ChooseAlgorithm()
        {
            Console.WriteLine("Wybierz algorytm:\n1. FCFS\n2. SSTF\n3. SCAN\n4. C-SCAN\n5. EDF\n6. FD-SCAN");
            choice = int.Parse(Console.ReadLine());
            Request r;
            requestsCopy.Clear();
            foreach(Request req in requests)
            {
                r = new Request(1, 1);
                r.Deadline = req.Deadline;
                r.EntryTime = req.EntryTime;
                r.Position = req.Position;
                requestsCopy.Add(r);
            }
            switch (choice)
            {
                case 1:
                    algorithm = new FCFS();
                    ((FCFS)algorithm).Processing(requestsCopy, max);
                    break;
                case 2:
                    algorithm = new SSTF();
                    ((SSTF)algorithm).Processing(requestsCopy, max);
                    break;
                case 3:
                    algorithm = new SCAN();
                    ((SCAN)algorithm).Processing(requestsCopy, max);
                    break;
                case 4:
                    algorithm = new C_SCAN();
                    ((C_SCAN)algorithm).Processing(requestsCopy, max);
                    break;
                case 5:
                    algorithm = new EDF();
                    ((EDF)algorithm).Processing(requestsCopy, max);
                    break;
                default:
                    loop = false;
                    break;
            }
            Console.WriteLine("Przebyta droga:");
            for(int i=0; i<algorithm.Path.Count; i++)
            {
                Console.Write(" " + algorithm.Path[i].Position + " |");
            }
            Console.WriteLine("\nDługosc przebytej drogi: " + algorithm.PathLength);
        }
    }
}
