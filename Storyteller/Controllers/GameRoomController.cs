using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Storyteller.Models;
using Storyteller.Services;

namespace Storyteller.Controllers
{
    public class GameRoomController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly GameRoomService _gameRoomService;

        public GameRoomController(ILogger<HomeController> logger, GameRoomService gameRoomService)
        {
            _logger = logger;
            _gameRoomService = gameRoomService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("GameRoom/UserPairing/{ScriptID}")]
        public IActionResult UserPairing(string ScriptID)
        {
            var result = _gameRoomService.GetGameCharacter(ScriptID);
            ViewBag.ScriptJsonString = JsonConvert.SerializeObject(result);
            return View();
        }

        public IActionResult StoryRoom(string id)
        {
            ViewBag.test = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CGTestRoom()
        {
            return View();
        }

        public IActionResult EndStoryRoom()
        {
            return View();
        }
    }
}
