using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class Script
    {
        public Script()
        {
            BestCreation = new HashSet<BestCreation>();
            ScriptJsonone = new HashSet<ScriptJsonone>();
        }

        public int ScriptId { get; set; }
        public int ScriptCategoryId { get; set; }
        public string ScriptName { get; set; }
        public int? ScriptMaxPlayer { get; set; }
        public string ScriptDuration { get; set; }
        public string ScriptIntroduction { get; set; }
        public int? ScriptBeenPlayedCount { get; set; }
        public DateTime? ScriptLaunchedDate { get; set; }
        public string ScriptUrl { get; set; }

        public virtual ScriptCategory ScriptCategory { get; set; }
        public virtual ICollection<BestCreation> BestCreation { get; set; }
        public virtual ICollection<ScriptJsonone> ScriptJsonone { get; set; }
    }
}
