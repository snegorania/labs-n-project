using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class TamagochEventArgs : EventArgs
    {
        public bool isBad { get; set; }
        public string massage { get; set; }
    }
}
