using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class Frame
    {
        int physicalLocation;
        public Page PageInside { get; set; }
        public Frame(int physicalLocation)
        {
            this.physicalLocation = physicalLocation;
        }
    }
}
