using System;
using System.Collections.Generic;

namespace Storyteller.DBModels
{
    public partial class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }
        public int? UserGender { get; set; }
    }
}
