using Microsoft.EntityFrameworkCore;

namespace Aula_de_EntityFramework.Data
{
    public class Aula_de_EntityFrameworkContext : DbContext
    {
        public Aula_de_EntityFrameworkContext(DbContextOptions<Aula_de_EntityFrameworkContext> options)
            : base(options)
        {

        }
        public DbSet<Aula_de_EntityFramework.Models.Contato> Contato { get; set; } = default!;
        public DbSet<Aula_de_EntityFramework.Models.Locais>? Locais { get; set; }
        public DbSet<Aula_de_EntityFramework.Models.Compromisso>? Compromisso { get; set; }
    }
}
