using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM.Models;

namespace PIM.Repository.Mappings
{
    public class CarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasMany(c => c.produtos).WithOne(ic => ic.carrinho).HasForeignKey(ic => ic.carrinhoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.cliente).WithMany(c => c.carrinhos).HasForeignKey(c => c.clienteId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
