using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webtest.Objects;

namespace webtest.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(150);
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            //Um prod está relac a apenas uma categ//mas uma categ pode ter N produt//chave estrageir categId
            //E nosso relacion é um para N, NÃO zero para N.
            builder.HasOne(p => p.Categoria).WithMany(p => p.Produto).HasForeignKey(p => p.CategoriaId).IsRequired();
            //um prod pode ter várias movi/mas uma movi está relac a apenas uma prod
            builder.HasMany(p => p.Movimentacao).WithOne(p => p.Produto);

            builder.ToTable("Produtos");
        }
    }
}
