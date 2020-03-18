using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDysku
{
    class Request: IComparable
    {
        public int EntryTime { get; set; }
        public int Position { get; set; }
        public int Deadline { get; set; }
        public Request(int max, int quantity)
        {
            Random rnd = new Random();
            EntryTime = rnd.Next(1, quantity * 5);
            System.Threading.Thread.Sleep(10);
            Position = rnd.Next(1, max);
            System.Threading.Thread.Sleep(10);
            Deadline = rnd.Next(quantity, quantity*5);
            System.Threading.Thread.Sleep(10);
        }
        public int CompareTo(object obj)
        {
            return EntryTime.CompareTo(((Request)obj).EntryTime);
        }
    }
}
