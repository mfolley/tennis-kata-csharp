using System.Collections.Generic;

namespace TennisKata
{
    internal class TennisGame
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; internal set; }
        private readonly Dictionary<int, string> Scores = new Dictionary<int, string>
        {
            { 0, "love" },
            { 1, "fifteen" },
            { 2, "thirty" },
            { 3, "forty" }
        };

        internal string GetScore()
        {
            if (Player1.Points >= 4 && Player1.Points - Player2.Points >= 2) return "Player1 wins";
            if (Player2.Points >= 4 && Player2.Points - Player1.Points >= 2) return "Player2 wins";
            if (Player1.Points == Player2.Points && Player1.Points >= 3) return "Deuce";
            if (Player1.Points >= 4) return "Advantage player1";
            if (Player2.Points >= 4) return "Advantage player2";
            if (Player1.Points == Player2.Points) return $"{Scores[Player1.Points]} - all";
            return $"{Scores[Player1.Points]} - {Scores[Player2.Points]}";
        }
    }
}