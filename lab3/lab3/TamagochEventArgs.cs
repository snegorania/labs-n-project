using System;

namespace lab3
{
    class TamagochEventArgs : EventArgs
    {
        public bool isBad { get; set; }
        public string massage { get; set; }
    }
}
