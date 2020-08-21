using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Storyteller.DBModels;
using Storyteller.Models;
using Storyteller.Services;
using Storyteller.ViewModels;

namespace Storyteller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HomeService _homeService;

        public HomeController(ILogger<HomeController> logger, HomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var result = _homeService.GetHomeViewModel();
            return View(result);
        }

        [HttpPost]
        public IEnumerable<AchievementViewModel> Achievement(string UserID)
        {
            var result = _homeService.GetAchievement(UserID);
            return result;
        }

        [Route("Home/Category/{id}")]
        public IActionResult Category(string id)
        {
            var result = _homeService.GetCategoryScript(id);
            return View(result);
        }

        [Route("Home/ScriptDetail/{CategoryID}/{scriptID}")]
        public IActionResult ScriptDetail(string CategoryID, string scriptID)
        {
            var result = _homeService.GetScript(scriptID);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult SaveUserData(string jdata)
        {
            UserViewModel UVM = JsonConvert.DeserializeObject<UserViewModel>(jdata);
            _homeService.ViewToModel(UVM);
            return Ok();
        }
    }
}
