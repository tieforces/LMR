using System;

namespace LegendaryMarvelRandomizer.Core.Models
{
    public class Mastermind
    {
        public string AdditionalInfo { get; set; }
        public Guid Id { get; set; }
        public string MasterStrike { get; set; }
        public string Name { get; set; }
        public Set Set { get; set; }
        public VillainDeck VillainDeck { get; set; }
    }
}
