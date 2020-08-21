using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.ViewModels
{
    public class GameRoomViewModel
    {
        public int ScriptId { get; set; }
        public string ScriptName { get; set; }
        public string CharacterImage { get; set; }
        public string CharacterName { get; set; }
        public string CharacterIntroduction { get; set; }
        public bool Choose { get; set; }
    }
}
