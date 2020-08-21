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
    public class GameRoomRepository
    {
        public static string connString;
        public SqlConnection conn;
        public GoodGood_DBContext context;

        private readonly GoodGood_DBContext _context;

        public GameRoomRepository(GoodGood_DBContext context, IConfiguration config)
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

        public List<GameRoomViewModel> GetCharacter(string ScriptID)
        {
            List<GameRoomViewModel> getCharacter;
            using (conn = new SqlConnection(connString))
            {
                string sql = @$"select s.ScriptName,sd.ScriptId,sd.CharacterImage,sd.CharacterName,sd.CharacterIntroduction
                                from ScriptDetail sd
                                inner join Script s on sd.ScriptID = s.ScriptID
                                where sd.ScriptId = {ScriptID}";


                getCharacter = conn.Query<GameRoomViewModel>(sql).ToList();
            }
            return getCharacter;
        }
    }
}
