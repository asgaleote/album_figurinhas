using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class AlbumFigurinhasContext : DbContext
    {
        public AlbumFigurinhasContext(DbContextOptions<AlbumFigurinhasContext> options)
            : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Figurinha> Figurinhas { get; set; }

    }
}