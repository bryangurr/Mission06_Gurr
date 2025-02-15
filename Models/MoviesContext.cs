using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Mission06_Gurr.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) // constructor to build database connection
        {
        }
        public DbSet<Movie> Movies { get; set; }

    }
}
