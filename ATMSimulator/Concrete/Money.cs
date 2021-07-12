using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    public struct Money
    {
        public int Amount { get; set; }

        public Dictionary<PaperNote, int> Notes { get; set; }

    }
}
