using Storyteller.Repository;
using Storyteller.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.Services
{
    public class GameRoomService
    {
        public readonly GameRoomRepository _gameRoomRepository;

        public GameRoomService(GameRoomRepository gameRoomRepository)
        {
            _gameRoomRepository = gameRoomRepository;
        }

        public IEnumerable<GameRoomViewModel> GetGameCharacter(string ScriptID)
        {
            return _gameRoomRepository.GetCharacter(ScriptID);
        }
    }
}
