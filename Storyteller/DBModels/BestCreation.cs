using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class BestCreation
    {
        public int BestCreationId { get; set; }
        public int ScriptId { get; set; }
        public string CreationContent { get; set; }
        public int? CreationBeenLikedCount { get; set; }

        public virtual Script Script { get; set; }
    }
}
