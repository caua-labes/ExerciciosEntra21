using Atividade1_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Atividade1_API.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        public DbSet<Models.User> usuario { get; set; }
    }
}
