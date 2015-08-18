using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace MarketFinder.AnalyticsService
{
    public class MarketsDataRepository
    {
        public IEnumerable<Rating> GetRatings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MarketManagementServiceDb"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Rating>("SELECT * FROM Ratings");
            }
        }
    }
}