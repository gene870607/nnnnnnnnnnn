using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Storyteller.DBModels;
using Storyteller.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.Repository
{
    public class HomeRepository
    {
        public static string connString;
        public SqlConnection conn;
        public GoodGood_DBContext context;

        private readonly GoodGood_DBContext _context;

        public HomeRepository(GoodGood_DBContext context, IConfiguration config)
        {
            _context = context;

            if (string.IsNullOrEmpty(connString))
            {
                connString = config.GetConnectionString("GoodGood_DBContext");
            }
            if (conn == null)
            {
                conn = new SqlConnection(connString);
            }
        }

        public List<HomeScriptCategory> GetHomeScriptCategory()
        {
            List<HomeScriptCategory> ScriptCategory;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select s.ScriptCategoryID, s.CurrentOnlinePlayerCount,s.ScriptCategoryUrl
                                from ScriptCategory s";
                ScriptCategory = conn.Query<HomeScriptCategory>(sql).ToList();
            }
            return ScriptCategory;
        }

        public List<NewScript> GetHomeNewScripts()
        {
            List<NewScript> NewScripts;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select s.ScriptID,img.ImgUrl,S.ScriptLaunchedDate
                                from Script s 
                                inner join Img img ON s.ScriptID = img.ScriptID
                                order by s.ScriptLaunchedDate desc";
                NewScripts = conn.Query<NewScript>(sql).ToList();
            }
            return NewScripts;
        }

        public List<UserItems> GetHomeTopUser()
        {
            List<UserItems> TopUser;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select TOP 10
                                u.UserID,u.UserName,u.UserImg,ud.UserScore
                                from [User] u 
                                inner join UserData ud ON ud.UserID = u.UserID
                                order by ud.UserScore desc";
                TopUser = conn.Query<UserItems>(sql).ToList();
            }
            return TopUser;
        }

        public List<BestScript> GetHomeTopScript()
        {
            List<BestScript> TopScript;
            using (conn = new SqlConnection(connString))
            {
                string sql = @" SELECT DISTINCT BestCreationID,b.ScriptID,s.ScriptUrl
                                ,CreationContent
                                ,CreationBeenLikedCount
                                , STUFF(
                                (
                                SELECT '，' +  cast(bd.UserID as nvarchar)
                                from BestCreation b, [BestCreationDetail] bd
                                where b.BestCreationID =bd.BestCreationID
                                FOR XML PATH('')
                                ),1,1,'') AS userid
                                FROM BestCreation b
                                inner join Script s on b.ScriptID = s.ScriptID
                                order by CreationBeenLikedCount desc";
                TopScript = conn.Query<BestScript>(sql).ToList();
            }
            return TopScript;
        }

        public IEnumerable<AchievementViewModel> GetAchievement(string UserID)
        {
            IEnumerable<AchievementViewModel> Achievement;
            using (conn = new SqlConnection(connString))
            {
                string sql = @$"select 
                                u.UserID,ud.DisplayAchievement
                                from [User] u 
                                inner join UserData ud ON ud.UserID = u.UserID
                                where u.UserID = {UserID}";
                Achievement = conn.Query<AchievementViewModel>(sql);
            }
            return Achievement;
        }


        public List<CategoryViewModel> GetCategoryScript(string categoryID)
        {
            List<CategoryViewModel> CategoryScript;
            using (conn = new SqlConnection(connString))
            {
                string sql = @$" select
                                sc.Tag,s.ScriptID,s.ScriptCategoryId,s.ScriptName,s.ScriptMaxPlayer,
                                ScriptDuration,ScriptUrl
                                from Script s
                                inner join ScriptCategory sc on sc.ScriptCategoryId = s.ScriptCategoryId
                                where s.ScriptCategoryId = {categoryID}";
                CategoryScript = conn.Query<CategoryViewModel>(sql).ToList();
            }
            return CategoryScript;
        }

        public IEnumerable<ScriptViewModel> GetScript(string scriptID)
        {
            IEnumerable<ScriptViewModel> Script;
            using (conn = new SqlConnection(connString))
            {
                string sql = @$"select
                                ScriptID,ScriptCategoryId,ScriptName,ScriptMaxPlayer,
                                ScriptDuration,ScriptIntroduction,ScriptUrl
                                from Script 
                                where ScriptID = {scriptID}";
                Script = conn.Query<ScriptViewModel>(sql);
            }
            return Script;
        }

        public void CreateUser(User UserData)
        {
            GoodGood_DBContext dbcontext = new GoodGood_DBContext();
            using (var _context = new GoodGood_DBContext())
            {
                var repo = new GDRepository<User>(_context);
                var result = dbcontext.User.Any((x) => x.UserId == UserData.UserId);
                if (!result)
                {
                    //var repo = new GDRepository<User>(_context);
                    repo.Create(UserData);
                    _context.SaveChanges();
                }else
                {
                    repo.UserUpdate(UserData);
                    _context.SaveChanges();
                }
            }
        }
    }
}
