using LMR.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LMR.Core.Data;
using LMR.Core.Managers;
using MarvelLegendaryRandomizer.MongoLMR;

namespace LMR.DatabaseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new MongoLMRRepository();
            var _manager = new LMRManager(repository);

            _manager.SaveHenchmen(GetHenchmen());
            _manager.SaveHeroes(GetHeroes());
            _manager.SaveMasterminds(GetMasterminds());
            _manager.SaveSchemes(GetSchemes());
            _manager.SaveVillains(GetVillains());
        }

        private static IEnumerable<Henchmen> GetHenchmen()
        {
            var cards = new List<Henchmen>();

            using (StreamReader r = new StreamReader(@"C:\Dev\Personal\LMR\LMR.Web\App_Data\legendary-henchmen.json"))
            {
                string json = r.ReadToEnd();
                cards = JsonConvert.DeserializeObject<List<Henchmen>>(json);
            }

            return cards.OrderBy(x => x.Name);
        }

        public static IEnumerable<Hero> GetHeroes()
        {
            var cards = new List<Hero>();

            using (StreamReader r = new StreamReader(@"C:\Dev\Personal\LMR\LMR.Web\App_Data\legendary-heroes.json"))
            {
                string json = r.ReadToEnd();
                cards = JsonConvert.DeserializeObject<List<Hero>>(json);
            }

            return cards.OrderBy(x => x.Name);
        }

        public static IEnumerable<Mastermind> GetMasterminds()
        {
            var cards = new List<Mastermind>();

            using (StreamReader r = new StreamReader(@"C:\Dev\Personal\LMR\LMR.Web\App_Data\legendary-masterminds.json"))
            {
                string json = r.ReadToEnd();
                cards = JsonConvert.DeserializeObject<List<Mastermind>>(json);
            }

            return cards.OrderBy(x => x.Name);
        }

        public static IEnumerable<Scheme> GetSchemes()
        {
            var cards = new List<Scheme>();

            using (StreamReader r = new StreamReader(@"C:\Dev\Personal\LMR\LMR.Web\App_Data\legendary-schemes.json"))
            {
                string json = r.ReadToEnd();
                cards = JsonConvert.DeserializeObject<List<Scheme>>(json);
            }

            return cards.OrderBy(x => x.Name);
        }

        private static IEnumerable<Villain> GetVillains()
        {
            var cards = new List<Villain>();

            using (StreamReader r = new StreamReader(@"C:\Dev\Personal\LMR\LMR.Web\App_Data\legendary-villains.json"))
            {
                string json = r.ReadToEnd();
                cards = JsonConvert.DeserializeObject<List<Villain>>(json);
            }

            return cards.OrderBy(x => x.Name);
        }
    }
}
