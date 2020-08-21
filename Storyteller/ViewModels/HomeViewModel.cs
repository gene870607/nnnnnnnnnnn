using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.ViewModels
{
    public class HomeViewModel
    {
        public List<HomeScriptCategory> HomeScriptCategory { get; set; } //有哪些劇本分類 搞笑,愛情,恐怖......
        public List<NewScript> NewScripts { get; set; } //新的劇本
        public List<UserItems> TopUser { get; set; } //最受歡迎的使用者
        public List<BestScript> TopScript { get; set; } //創作出來的故事最受歡迎
    }

    public class HomeScriptCategory
    {
        public int ScriptCategoryId { get; set; }
        public int? CurrentOnlinePlayerCount { get; set; }
        public string ScriptCategoryUrl { get; set; }
    }

    public class NewScript
    {
        public int ScriptId { get; set; }
        public string ImgUrl { get; set; }
    }

    public class UserItems
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }
    }

    public class BestScript
    {
        public int BestCreationId { get; set; }
        public int ScriptId { get; set; }
        public string ScriptUrl { get; set; }
        public string UserId { get; set; }
        public string UserImg { get; set; }
        public int? CreationBeenLikedCount { get; set; }
    }
}
