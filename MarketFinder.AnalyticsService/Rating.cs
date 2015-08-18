namespace MarketFinder.AnalyticsService
{
    public class Rating
    {
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }

        public int MarketId { get; set; }
    }
}