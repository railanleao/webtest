using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webtest.Objects;

namespace webtest.Mapeamento
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(m => m.MovimentacaoId);
            
            builder.Property(m => m.Descricao).HasMaxLength(500).IsRequired();

            builder.Property(m => m.DataHora).IsRequired();

            builder.HasOne(m => m.Produto).WithMany(m => m.Movimentacao).HasForeignKey(m => m.ProdutoId).IsRequired();

            builder.ToTable("Movimentações");
        }
    }
}
