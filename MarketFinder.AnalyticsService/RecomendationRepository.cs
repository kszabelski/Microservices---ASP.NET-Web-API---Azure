using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace MarketFinder.AnalyticsService
{
    public class RecomendationRepository
    {
        public void Insert(string userEmail, int marketId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RecommendationsDb"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "INSERT Recommendations (UserEmail, MarketId) VALUES (@userEmail, @marketId)",
                    new { userEmail, marketId});
            }
        }
    }
}