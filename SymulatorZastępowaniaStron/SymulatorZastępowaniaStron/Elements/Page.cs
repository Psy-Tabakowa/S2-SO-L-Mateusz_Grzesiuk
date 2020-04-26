using System;
using System.Collections.Generic;
using System.Text;


namespace SymulatorZastępowaniaStron
{
    class Page
    {
        public bool SecondChance { get; set; } = false;
        public int LogicalLocation { get; set; } = 0;
        public int PhysicalLocation { get; set; } = 0;
        public int TimeInPhysical { get; set; } = 0;
        public int WaitingForRef { get; set; } = 0;

        public Page(int logicalLocation)
        {
            this.LogicalLocation = logicalLocation;
        }

        
    }
}
