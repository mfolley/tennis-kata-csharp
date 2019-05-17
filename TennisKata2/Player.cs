using System;

namespace TennisKata2
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