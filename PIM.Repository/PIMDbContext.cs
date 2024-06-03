using Microsoft.EntityFrameworkCore;
using PIM.Models;
using System.Reflection;

namespace PIM.Repository
{
    public class PIMDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Vendedor> vendedores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Carrinho> carrinhos { get; set; }
        public DbSet<ItemCarrinho> itensCarrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
