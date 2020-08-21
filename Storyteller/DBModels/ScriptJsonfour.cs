using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class ScriptJsonfour
    {
        public int? GoSectionIndex { get; set; }
        public int? Id { get; set; }
        public int? SectionIndex { get; set; }

        public virtual ScriptJsonthree GoSectionIndexNavigation { get; set; }
    }
}
