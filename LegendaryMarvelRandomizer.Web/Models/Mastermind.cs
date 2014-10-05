using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegendaryMarvelRandomizer.Web.Models
{
    public class Mastermind : Card
    {
        public string AdditionalInfo { get; set; }
        public string MasterStrike { get; set; }
        public VillainDeck VillainDeck { get; set; }
    }
}