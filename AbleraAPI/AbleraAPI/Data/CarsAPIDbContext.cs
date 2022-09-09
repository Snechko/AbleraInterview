using Microsoft.EntityFrameworkCore;
using AbleraAPI.Models;

namespace AbleraAPI.Data
{
    public class CarsAPIDbContext: DbContext
    {
        public CarsAPIDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
