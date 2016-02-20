using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMR.Web.Models
{
    public class Schemes : Card
    {
        public string EvilWins { get; set; }
        public HeroDeck HeroDeck { get; set; }
        public string SpecialRules { get; set; }
        public string Twist { get; set; }
        public VillainDeck VillainDeck { get; set; }
    }
}