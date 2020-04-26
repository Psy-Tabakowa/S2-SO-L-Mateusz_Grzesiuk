using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class Frame
    {
        public Proces ProcesID { get; set; } = null;
        public int WaitingForRef { get; set; } = 0;
        public Page Page { get; set; } = null;
    }
}
