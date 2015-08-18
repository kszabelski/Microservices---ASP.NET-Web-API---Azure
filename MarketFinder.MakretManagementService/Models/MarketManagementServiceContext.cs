using System.Data.Entity;

namespace MarketFinder.MakretManagementService.Models
{
    public class MarketManagementServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MarketManagementServiceContext() : base("name=MarketManagementServiceContext")
        {
        }

        public System.Data.Entity.DbSet<Market> Markets { get; set; }

        public System.Data.Entity.DbSet<MarketFinder.MakretManagementService.Models.Rating> Ratings { get; set; }
    
    }
}
