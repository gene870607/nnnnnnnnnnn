using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class ScriptCategory
    {
        public ScriptCategory()
        {
            Script = new HashSet<Script>();
        }

        public int ScriptCategoryId { get; set; }
        public string Tag { get; set; }
        public int? CurrentOnlinePlayerCount { get; set; }
        public string ScriptCategoryUrl { get; set; }

        public virtual ICollection<Script> Script { get; set; }
    }
}
