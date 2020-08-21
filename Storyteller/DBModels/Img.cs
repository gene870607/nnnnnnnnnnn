using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class Img
    {
        public int ScriptId { get; set; }
        public string ImgUrl { get; set; }

        public virtual Script Script { get; set; }
    }
}
