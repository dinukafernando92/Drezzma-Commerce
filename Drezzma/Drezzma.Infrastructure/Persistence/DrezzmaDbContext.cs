using Microsoft.EntityFrameworkCore;

namespace Drezzma.Infrastructure.Persistence
{
    public class DrezzmaDbContext :DbContext
    {
        public DrezzmaDbContext(DbContextOptions<DrezzmaDbContext> options) : base(options)
        {
        }
    }
}
