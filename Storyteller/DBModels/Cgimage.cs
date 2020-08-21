using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class Cgimage
    {
        public int ScriptId { get; set; }
        public string Url { get; set; }

        public virtual Script Script { get; set; }
    }
}
