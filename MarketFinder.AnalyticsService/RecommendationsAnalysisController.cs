using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;

namespace MarketFinder.AnalyticsService
{
    public class RecommendationsAnalysisController : ApiController
    {
        private readonly MarketsDataRepository _marketsDataRepository = new MarketsDataRepository();
        private readonly RecomendationRepository _recomendationRepository = new RecomendationRepository();

        [HttpPost]
        public void GenerateRecomendations()
        {
            var ratings = _marketsDataRepository.GetRatings();

            var userToFavouriteMarkets = new Dictionary<string, List<int>>();
            var userRatings = ratings.GroupBy(r=>r.UserEmail);
            foreach (var userRating in userRatings)
            {
                userToFavouriteMarkets[userRating.Key] = userRating.OrderByDescending(r => r.Rate).Take(3).Select(r => r.MarketId).ToList();
            }

            foreach (var userRating in userRatings)
            {
                var userFavourites = userRating.OrderByDescending(r => r.Rate).Take(5).Select(r => r.MarketId).ToArray();
                var usersWithSimilarRecommendations = userToFavouriteMarkets.Select(u=>u.Value).Where(ufm => ufm.Any(r => userFavourites.Contains(r)));

                var userRecomendations = usersWithSimilarRecommendations.SelectMany(u => u).Distinct().Except(userRating.Select(u=>u.MarketId)).ToList();

                foreach (var userRecomendation in userRecomendations)
                {
                    _recomendationRepository.Insert(userRating.Key, userRecomendation);
                }
            }
        }
    }
}
