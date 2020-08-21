using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class UserData
    {
        public string UserId { get; set; }
        public int? UserScore { get; set; }
        public int? UserBeenLikedCount { get; set; }
        public int? UserBeenReportedCount { get; set; }
        public string DisplayAchievement { get; set; }

        public virtual User User { get; set; }
    }
}
