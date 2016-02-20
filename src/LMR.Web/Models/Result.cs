using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMR.Web.Models
{
    public class Result
    {
        public int NumberOfPlayers { get; set; }
        public string MasterMind { get; set; }
        public string Scheme { get; set; }
        public IEnumerable<string> Villains { get;set; }
        public IEnumerable<string> Heroes { get; set; }
        public IEnumerable<string> Henchmen { get; set; }
        public int NumberOfBystanders { get; set; }
        public int NumberOfVillains { get; set; }
        public int NumberOfHenchmen { get; set; }
        public int NumberOfHeroes { get; set; }
    }
}