using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIM.Models;

namespace PIM.Repository.Mappings
{
    internal class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.HasKey(ic => new { ic.carrinhoId, ic.produtoId });
        }
    }
}
