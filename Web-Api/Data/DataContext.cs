using Microsoft.EntityFrameworkCore;


namespace Web_Api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
            
        }
        public DbSet<SubscriptionUser> SubscriptionUsers { get; set; }
    }
}
