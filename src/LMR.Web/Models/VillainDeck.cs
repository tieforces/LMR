using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMR.Web.Models
{
    public class VillainDeck
    {
        public string AdditionalInfo { get; set; }
        public int Bystanders { get; set; }
        public int ExtraHenchmen { get; set; }
        public string Henchmen { get; set; }
        public string Villain { get; set; }
        public int Twists { get; set; }
        public int ExtraVillain { get; set; }
    }
}