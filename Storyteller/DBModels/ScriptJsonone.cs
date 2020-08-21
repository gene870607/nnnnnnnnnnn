using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class ScriptJsonone
    {
        public ScriptJsonone()
        {
            ScriptJsontwo = new HashSet<ScriptJsontwo>();
        }

        public int? ScriptId { get; set; }
        public int CharacterId { get; set; }
        public string Roles { get; set; }
        public string MainText { get; set; }
        public string RolesImg { get; set; }

        public virtual Script Script { get; set; }
        public virtual ICollection<ScriptJsontwo> ScriptJsontwo { get; set; }
    }
}
