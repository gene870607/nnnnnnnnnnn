using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class ScriptJsontwo
    {
        public ScriptJsontwo()
        {
            ScriptJsonthree = new HashSet<ScriptJsonthree>();
        }

        public int? CharacterId { get; set; }
        public int? SectionIndex { get; set; }
        public string Conversation { get; set; }
        public string Cgimg { get; set; }
        public string Script { get; set; }
        public bool? Choose { get; set; }
        public string Issue { get; set; }
        public bool? Event { get; set; }
        public int TrueOrFalse { get; set; }

        public virtual ScriptJsonone Character { get; set; }
        public virtual ICollection<ScriptJsonthree> ScriptJsonthree { get; set; }
    }
}
