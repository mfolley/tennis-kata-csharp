using System;

namespace TennisKata
{
    internal class Player
    {
        public int Points { get; set; }

        internal void WinsPoint()
        {
            Points++;
        }
    }
}