using Microsoft.EntityFrameworkCore;
using reactWebAPI.Data.Entities;

namespace reactWebAPI.Data
{
    public class ReactJSDemoContext : DbContext
    {
        public ReactJSDemoContext(DbContextOptions<ReactJSDemoContext> context) : base (context)
        {

        }
        public DbSet<SuperDeveloper> SuperDeveloper { get; set; }

    }
}
