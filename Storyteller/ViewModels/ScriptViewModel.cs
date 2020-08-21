using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.ViewModels
{
    public class ScriptViewModel
    {
        public int ScriptId { get; set; }
        public string ScriptUrl { get; set; }
        public string ScriptName { get; set; }
        public int? ScriptMaxPlayer { get; set; }
        public string ScriptDuration { get; set; }
        public string ScriptIntroduction { get; set; }
    }
}
