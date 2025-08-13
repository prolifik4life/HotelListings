using Microsoft.EntityFrameworkCore;

namespace HotelListings.Api.Data
{
    public class HotelsListingDbContext :  DbContext
    {
        public HotelsListingDbContext(DbContextOptions<HotelsListingDbContext> options) : base(options) 
        { }

        DbSet<Country> Countries { get; set; }
        DbSet<Hotel> Hotels { get; set; }
    }
}
