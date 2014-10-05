using System;

namespace LegendaryMarvelRandomizer.Core.Models
{
    public class Game
    {
        public DateTime DatePlayed { get; set; }
        public Henchmen[] Henchmen { get; set; }
        public Hero[] Heroes { get; set; }
        public Guid Id { get; set; }
        public Mastermind Mastermind { get; set; }
        public string Names { get; set; }
        public int NumberOfPlayers { get; set; }
        public Scheme Scheme { get; set; }
        public int? Score { get; set; }
        public Villain[] Villains { get; set; }
        public bool? Won { get; set; }
    }
}
