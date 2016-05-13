using LMR.Core.Models;
using LMR.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMR.Web.Controllers
{
    public class HomeController : Controller
    {
        // this is a test!!
        #region Member Variables

        Core.Managers.ILMRManager _manager;

        #endregion

        #region Constructors

        public HomeController(Core.Managers.ILMRManager manager)
        {
            if(manager == null)
            {
                // todo throw exception
            }

            _manager = manager;
        }

        #endregion

        #region Action Methods

        [HttpGet]
        public ActionResult Index()
        {
            var homeViewModel = new Home();
            homeViewModel.Games = _manager.GetAllGames();
            homeViewModel.Henchmen = _manager.GetAllHenchmen();
            homeViewModel.Heroes = _manager.GetAllHeroes();
            homeViewModel.Masterminds = _manager.GetAllMasterminds();
            homeViewModel.Schemes = _manager.GetAllSchemes();
            homeViewModel.Villains = _manager.GetAllVillains();
            homeViewModel.NewGame = new Game();
            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(Home home)
        {
            //switch(home.NumberOfPlayersSelected)
            //{
            //    case 1:
            //        home.Result.NumberOfBystanders = 1;
            //        home.Result.NumberOfHenchmen = 1;
            //        home.Result.NumberOfVillains = 1;
            //        home.Result.NumberOfHeroes = 5;
            //        break;
            //    case 2:
            //        home.Result.NumberOfBystanders = 2;
            //        home.Result.NumberOfHenchmen = 1;
            //        home.Result.NumberOfVillains = 2;
            //        home.Result.NumberOfHeroes = 5;
            //        break;
            //    case 3:
            //        home.Result.NumberOfBystanders = 8;
            //        home.Result.NumberOfHenchmen = 1;
            //        home.Result.NumberOfVillains = 3;
            //        home.Result.NumberOfHeroes = 5;
            //        break;
            //    case 4:
            //        home.Result.NumberOfBystanders = 8;
            //        home.Result.NumberOfHenchmen = 2;
            //        home.Result.NumberOfVillains = 3;
            //        home.Result.NumberOfHeroes = 6;
            //        break;
            //    case 5:
            //        home.Result.NumberOfBystanders = 12;
            //        home.Result.NumberOfHenchmen = 2;
            //        home.Result.NumberOfVillains = 4;
            //        home.Result.NumberOfHeroes = 6;
            //        break;
            //}

            //home.Result = GetResult(home);
            return View(home);
        }

        [HttpPost]
        public ActionResult Save(Game game)
        {
            game.DatePlayed = DateTime.Now;
            _manager.SaveGame(game);
            return null;
        }

        #endregion
    }
}
