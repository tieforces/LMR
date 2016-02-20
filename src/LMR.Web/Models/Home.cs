using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMR.Core.Utils;

namespace LMR.Web.Models
{
    public class Home
    {
        public IEnumerable<Core.Models.Game> Games { get; set; }
        public IEnumerable<Core.Models.Henchmen> Henchmen { get; set; }
        public IEnumerable<Core.Models.Hero> Heroes { get; set; }
        public IEnumerable<Core.Models.Mastermind> Masterminds { get; set; }
        public Core.Models.Game NewGame { get; set; }
        public IEnumerable<Core.Models.Scheme> Schemes { get; set; }
        public IEnumerable<Core.Models.Villain> Villains { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Sets
        {
            get
            {
                var sets = Enum.GetValues(typeof(Core.Models.Set))
                    .Cast<Core.Models.Set>()
                    .Select(x => new KeyValuePair<int, string>((int)x, x.GetDescription() ?? x.ToString()))
                    .OrderBy(x => x.Key)
                    .ToList();
                return sets;
            }
        }
        public IEnumerable<KeyValuePair<int, string>> Teams
        {
            get
            {
                var teams = Enum.GetValues(typeof(Core.Models.Team))
                    .Cast<Core.Models.Team>()
                    .Select(x => new KeyValuePair<int, string>((int)x, string.IsNullOrEmpty(x.GetDescription()) ? x.ToString() : x.GetDescription()))
                    .OrderBy(x => x.Key)
                    .ToList();
                return teams;
            }
        }
    }
}