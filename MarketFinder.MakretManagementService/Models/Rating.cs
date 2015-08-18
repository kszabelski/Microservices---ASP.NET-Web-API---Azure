namespace MarketFinder.MakretManagementService.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        public string UserEmail { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }

        // For simplicity of this demo code it lacks Forign Key here
        public int MarketId { get; set; }
    }
}