using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM.Models;

namespace PIM.Repository.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasMany(p => p.carrinho).WithOne(ic => ic.produto).HasForeignKey(ic => ic.produtoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.categoria).WithMany(c => c.produtos).HasForeignKey(c => c.categoriaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.vendedor).WithMany(c => c.produtos).HasForeignKey(c => c.vendedorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
