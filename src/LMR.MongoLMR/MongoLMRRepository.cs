using LMR.Core.Data;
using LMR.Core.Models;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvelLegendaryRandomizer.MongoLMR
{
    public class MongoLMRRepository : MongoRepositoryBase, ILMRRepository
    {
        #region Constructors

        #endregion

        #region Methods

        #region Game

        /// <summary>Gets all of the games in the database.</summary>
        /// <returns>Returns a collection of Core.Models.Game objects.</returns>
        public IEnumerable<Game> GetAllGames()
        {
            return Database.GetCollection<Game>("game").AsQueryable();
        }

        /// <summary>Load all of the completed games that have been played.</summary>
        /// <returns>Returns a collection of Game objects.</returns>
        public IEnumerable<Game> GetCompletedGames()
        {
            var games = Database.GetCollection<Game>("game");
            return games.AsQueryable().Where(x => x.Won != null);
        }

        /// <summary>Loads a game based on the Id.</summary>
        /// <param name="id">Used to indicate a game's Id.</param>
        /// <returns>Returns a Core.Models.Game object.</returns>
        public Game GetGameById(Guid id)
        {
            var games = Database.GetCollection<Game>("game");
            var game = games.AsQueryable().SingleOrDefault(x => x.Id == id);
            return game;
        }

        /// <summary>Saves a game to the database.</summary>
        /// <param name="game">Used to indicate a Core.Models.Game object.</param>
        public void SaveGame(Game game)
        {
            var games = Database.GetCollection<Game>("game");
            if(game.Id == null)
            {
                game.Id = Guid.NewGuid();
            }

            games.Save(game);
        }

        #endregion

        #region Henchmen

        /// <summary>Loads all of the henchmen.</summary>
        /// <returns>Returns a collection of Henchmen objects.</returns>
        public IEnumerable<Henchmen> GetAllHenchmen()
        {
            return Database.GetCollection<Henchmen>("henchmen").AsQueryable();
        }

        /// <summary>Saves a collection of henchmen to the database.</summary>
        /// <param name="henchmen">Used to indicate a collection of Core.Models.Henchmen objects.</param>
        public void SaveHenchmen(IEnumerable<Henchmen> henchmen)
        {
            var cards = Database.GetCollection<Henchmen>("henchmen");
            foreach (var h in henchmen)
            {
                if(!cards.AsQueryable().Any(x => x.Name == h.Name))
                {
                    h.Id = Guid.NewGuid();
                }
                else
                {
                    h.Id = cards.AsQueryable().Single(x => x.Name == h.Name).Id;
                }

                cards.Save(h);
            }
        }

        #endregion

        #region Hero

        /// <summary>Loads all of the heroes.</summary>
        /// <returns>Returns a collection of Hero objects.</returns>
        public IEnumerable<Hero> GetAllHeroes()
        {
            return Database.GetCollection<Hero>("hero").AsQueryable();
        }

        /// <summary>Saves a collection of Hero objects to the database.</summary>
        /// <param name="heroes">Used to indicate a collection of Core.Models.Hero objects.</param>
        public void SaveHeroes(IEnumerable<Hero> heroes)
        {
            var cards = Database.GetCollection<Hero>("hero");
            foreach (var h in heroes)
            {
                if (!cards.AsQueryable().Any(x => x.Name == h.Name))
                {
                    h.Id = Guid.NewGuid();
                }
                else
                {
                    h.Id = cards.AsQueryable().Single(x => x.Name == h.Name).Id;
                }

                cards.Save(h);
            }
        }

        #endregion

        #region Mastermind

        /// <summary>Loads all of the masterminds.</summary>
        /// <returns>Returns a collection of Mastermind objects.</returns>
        public IEnumerable<Mastermind> GetAllMasterminds()
        {
            return Database.GetCollection<Mastermind>("mastermind").AsQueryable();
        }
        
        /// <summary>Saves a collection of Mastermind objects to the database.</summary>
        /// <param name="masterminds">Used to indicate a collection of Core.Models.Mastermind objects.</param>
        public void SaveMasterminds(IEnumerable<Mastermind> masterminds)
        {
            var cards = Database.GetCollection<Mastermind>("mastermind");
            foreach (var m in masterminds)
            {
                if (!cards.AsQueryable().Any(x => x.Name == m.Name))
                {
                    m.Id = Guid.NewGuid();
                }
                else
                {
                    m.Id = cards.AsQueryable().Single(x => x.Name == m.Name).Id;
                }

                cards.Save(m);
            }
        }

        #endregion

        #region Scheme

        /// <summary>Loads all of the schemes.</summary>
        /// <returns>Returns a collection of Scheme objects.</returns>
        public IEnumerable<Scheme> GetAllSchemes()
        {
            return Database.GetCollection<Scheme>("scheme").AsQueryable();
        }

        /// <summary>Saves a collection of Scheme objects to the database.</summary>
        /// <param name="schemes">Used to indicate a collection of Core.Models.Scheme objects.</param>
        public void SaveSchemes(IEnumerable<Scheme> schemes)
        {
            var cards = Database.GetCollection<Scheme>("scheme");
            foreach (var s in schemes)
            {
                if (!cards.AsQueryable().Any(x => x.Name == s.Name))
                {
                    s.Id = Guid.NewGuid();
                }
                else
                {
                    s.Id = cards.AsQueryable().Single(x => x.Name == s.Name).Id;
                }

                cards.Save(s);
            }
        }

        #endregion

        #region Villain

        /// <summary>Loads all of the villains.</summary>
        /// <returns>Returns a collection of Villain objects.</returns>
        public IEnumerable<Villain> GetAllVillains()
        {
            return Database.GetCollection<Villain>("villain").AsQueryable();
        }

        /// <summary>Saves a collection of Villain objects to the database.</summary>
        /// <param name="villains">Used to indicate a collection of Core.Models.Villain objects.</param>
        public void SaveVillains(IEnumerable<Villain> villains)
        {
            var cards = Database.GetCollection<Villain>("villain");
            foreach (var v in villains)
            {
                if (!cards.AsQueryable().Any(x => x.Name == v.Name))
                {
                    v.Id = Guid.NewGuid();
                }
                else
                {
                    v.Id = cards.AsQueryable().Single(x => x.Name == v.Name).Id;
                }

                cards.Save(v);
            }
        }

        #endregion

        #endregion
    }
}
