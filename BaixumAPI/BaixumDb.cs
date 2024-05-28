using Microsoft.EntityFrameworkCore;

namespace BaixumAPI
{
    public class BaixumDb: DbContext
    {
        public BaixumDb(DbContextOptions<BaixumDb> options) : base(options)
        {

        }

        DbSet<Usuario> Usuarios => Set<Usuario>();
    }
}
