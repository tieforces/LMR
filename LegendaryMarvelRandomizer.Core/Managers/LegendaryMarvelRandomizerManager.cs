using LegendaryMarvelRandomizer.Core.Data;
using LegendaryMarvelRandomizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryMarvelRandomizer.Core.Managers
{
    public class LegendaryMarvelRandomizerManager : ILegendaryMarvelRandomizerManager
    {
        #region Private Members

        ILegendaryMarvelRandomizerRepository _repository;

        #endregion

        #region Constructors

        public LegendaryMarvelRandomizerManager(ILegendaryMarvelRandomizerRepository repository)
        {
            if(repository != null)
            {
                _repository = repository;
            }
        }

        #endregion

        #region Methods

        #region Games

        public Game[] GetAllGames()
        {
            return _repository.GetAllGames().ToArray();
        }

        public Game[] GetCompletedGames()
        {
            return _repository.GetCompletedGames().ToArray();
        }

        public Game GetGameById(Guid id)
        {
            return _repository.GetGameById(id);
        }

        public void SaveGame(Game game)
        {
            _repository.SaveGame(game);
        }

        #endregion

        #region Henchmen

        public Henchmen[] GetAllHenchmen()
        {
            return _repository.GetAllHenchmen().ToArray();
        }
        public Henchmen GetHenchmenById(int id)
        {
            // todo - implement
            return null;
        }
        public void SaveHenchmen(IEnumerable<Henchmen> henchmen)
        {
            _repository.SaveHenchmen(henchmen);
        }

        #endregion

        #region Hero

        public Hero[] GetAllHeroes()
        {
            return _repository.GetAllHeroes().ToArray();
        }
        public Hero GetHeroById(int id)
        {
            // todo - implement
            return null;
        }
        public void SaveHeroes(IEnumerable<Hero> heroes)
        {
            _repository.SaveHeroes(heroes);
        }

        #endregion

        #region Mastermind

        public Mastermind[] GetAllMasterminds()
        {
            return _repository.GetAllMasterminds().ToArray();
        }
        public Mastermind GetMastermindById(int id)
        {
            // todo - implement
            return null;
        }
        public void SaveMasterminds(IEnumerable<Mastermind> masterminds)
        {
            _repository.SaveMasterminds(masterminds);
        }

        #endregion

        #region Scheme

        public Scheme[] GetAllSchemes()
        {
            return _repository.GetAllSchemes().ToArray();
        }
        public Scheme GetSchemeById(int id)
        {
            // todo - implement
            return null;
        }
        public void SaveSchemes(IEnumerable<Scheme> schemes)
        {
            _repository.SaveSchemes(schemes);
        }

        #endregion

        #region Villain

        public Villain[] GetAllVillains()
        {
            return _repository.GetAllVillains().ToArray();
        }
        public Villain GetVillainById(int id)
        {
            // todo - implement
            return null;
        }
        public void SaveVillains(IEnumerable<Villain> villains)
        {
            _repository.SaveVillains(villains);
        }

        #endregion

        #endregion
    }
}
