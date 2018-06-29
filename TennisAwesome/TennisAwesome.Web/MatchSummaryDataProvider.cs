using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace TennisAwesome.Web
{
    public class MatchSummary
    {
        public DateTime MatchDate;
        public string Player1;
        public string Player2;
        public string Score;
    }

    public class MatchSummaryDataProvider
    {
        public MatchSummary[] GetAll()
        {
            string connectionString = @"Server=localhost;Database=TennisAwesome;User Id=sa;Password=P@ssw0rd1;";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                select
                    m.DatePlayed as MatchDate
                    , p1.PlayerName as Player1
                    , p2.PlayerName as Player2
                    , m.Score
                from Match m
                join Player  p1
                    on p1.PlayerId = m.Player1
                join Player  p2
                    on p2.PlayerId = m.Player2";
                
                return connection.Query<MatchSummary>(sql).ToArray();
            }
        }
    }
}