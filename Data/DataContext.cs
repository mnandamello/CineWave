using CineWave.Models;
using Microsoft.EntityFrameworkCore;

namespace CineWave.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Campanha> Campanhas { get; set;}

        public DbSet<Insights> Insights { get; set; }
    }
}
