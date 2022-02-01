using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webtest.Objects;

namespace webtest.Mapeamento

{
    public class ItenVendaMap : IEntityTypeConfiguration<ItenVenda>
    {
        public void Configure(EntityTypeBuilder<ItenVenda> builder)
        {
            builder.HasKey(i => i.ItenVendaId);
            //builder.Property(i => i.Descricao).HasMaxLength(500);
            builder.Property(iv => iv.Quantidade).IsRequired();
            builder.Property(iv => iv.Preco).IsRequired();
            builder.Property(iv => iv.Total).IsRequired();


            builder.HasOne(iv => iv.Cliente).WithMany(iv => iv.ItenVenda).HasForeignKey(iv => iv.ClienteId).IsRequired();
            builder.HasOne(iv => iv.Venda).WithMany(iv => iv.ItenVenda).HasForeignKey(iv => iv.ItenVendaId).IsRequired();
            builder.HasMany(iv => iv.Produtos).WithOne(iv => iv.ItenVenda).HasForeignKey(iv => iv.ProdutoId).IsRequired();
        }
    }
}
