using Microsoft.EntityFrameworkCore;

namespace BaixumAPI
{
    public class BaixumDb: DbContext
    {
        public BaixumDb(DbContextOptions<BaixumDb> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Artigo> Artigos => Set<Artigo>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
    }
}
