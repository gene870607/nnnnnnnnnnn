using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class ScriptJsonthree
    {
        public int? TrueOrFalse { get; set; }
        public string OptionDesc { get; set; }
        public bool? InputFlag { get; set; }
        public string InputText { get; set; }
        public string Input { get; set; }
        public int GoSectionIndex { get; set; }

        public virtual ScriptJsontwo TrueOrFalseNavigation { get; set; }
    }
}
