using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webtest.Objects;

namespace webtest.Mapeamento
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.NumVendaId);
            builder.Property(v => v.DataHora).IsRequired();

            builder.HasOne(v => v.Cliente).WithMany(v => v.Venda).HasForeignKey(v => v.ClienteId).IsRequired();
            builder.HasMany(v => v.Produtos).WithOne(v => v.Venda).HasForeignKey(v=>v.ProdutoId).IsRequired();

            builder.ToTable("Vendas");
        }
    }
}
