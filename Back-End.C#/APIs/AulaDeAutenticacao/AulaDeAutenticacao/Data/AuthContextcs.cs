using Microsoft.EntityFrameworkCore;

namespace AulaDeAutenticacao.Data
{
    public class AuthContextcs : DbContext
    {
        public AuthContextcs(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.User> usuario {  get; set; }
    }
}
