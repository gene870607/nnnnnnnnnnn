using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class ScriptDetail
    {
        public int ScriptId { get; set; }
        public string CharacterImage { get; set; }
        public string CharacterName { get; set; }
        public string CharacterIntroduction { get; set; }

        public virtual Script Script { get; set; }
    }
}
