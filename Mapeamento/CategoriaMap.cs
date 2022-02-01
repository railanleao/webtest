using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webtest.Objects;

namespace webtest.Mapeamento
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //Aqui você tá declarando chave primária
            builder.HasKey(c => c.CategoriaId);
            //Aqui você tá delimitando os caracteres e se ele é obrigatório ou não
            builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
            //Uma categ está relac a vários prod //Mas um prod está relacio a apenas uma categ
            builder.HasMany(C => C.Produto).WithOne(c => c.Categoria);
            
            
            builder.ToTable("Categorias");
        }
    }
}
