using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nomeproduto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.codigo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.preco).IsRequired().HasMaxLength(100);
            builder.Property(x => x.quant_estoque).IsRequired().HasMaxLength(100);
        }


    }
}
