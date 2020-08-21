using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class BestCreationDetail
    {
        public int BestCreationId { get; set; }
        public string UserId { get; set; }

        public virtual BestCreation BestCreation { get; set; }
        public virtual User User { get; set; }
    }
}
