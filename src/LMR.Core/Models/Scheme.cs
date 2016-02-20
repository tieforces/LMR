using System;

namespace LMR.Core.Models
{
    public class Scheme
    {
        public string EvilWins { get; set; }
        public HeroDeck HeroDeck { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Set Set { get; set; }
        public string SpecialRules { get; set; }
        public string Twist { get; set; }
        public VillainDeck VillainDeck { get; set; }
    }
}
