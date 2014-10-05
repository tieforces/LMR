using LegendaryMarvelRandomizer.Core.Models;
using System;
using System.Collections.Generic;

namespace LegendaryMarvelRandomizer.Core.Managers
{
    public interface ILegendaryMarvelRandomizerManager
    {
        Game[] GetAllGames();
        Game[] GetCompletedGames();
        Game GetGameById(Guid id);
        void SaveGame(Game game);
        Henchmen[] GetAllHenchmen();
        Henchmen GetHenchmenById(int id);
        void SaveHenchmen(IEnumerable<Henchmen> henchmen);
        Hero[] GetAllHeroes();
        Hero GetHeroById(int id);
        void SaveHeroes(IEnumerable<Hero> heroes);
        Mastermind[] GetAllMasterminds();
        Mastermind GetMastermindById(int id);
        void SaveMasterminds(IEnumerable<Mastermind> masterminds);
        Scheme[] GetAllSchemes();
        Scheme GetSchemeById(int id);
        void SaveSchemes(IEnumerable<Scheme> schemes);
        Villain[] GetAllVillains();
        Villain GetVillainById(int id);
        void SaveVillains(IEnumerable<Villain> villains);
    }
}
