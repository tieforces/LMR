using LMR.Core.Models;
using System;
using System.Collections.Generic;

namespace LMR.Core.Data
{
    public interface ILMRRepository
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetCompletedGames();
        Game GetGameById(Guid id);
        void SaveGame(Game game);
        IEnumerable<Henchmen> GetAllHenchmen();
        void SaveHenchmen(IEnumerable<Henchmen> henchmen);
        IEnumerable<Hero> GetAllHeroes();
        void SaveHeroes(IEnumerable<Hero> heroes);
        IEnumerable<Mastermind> GetAllMasterminds();
        void SaveMasterminds(IEnumerable<Mastermind> masterminds);
        IEnumerable<Scheme> GetAllSchemes();
        void SaveSchemes(IEnumerable<Scheme> schemes);
        IEnumerable<Villain> GetAllVillains();
        void SaveVillains(IEnumerable<Villain> villains);
    }
}
