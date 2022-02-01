using Microsoft.EntityFrameworkCore;
using webtest.Mapeamento;
using webtest.Objects;

namespace webtest.Connection
{
    public class EFContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public EFContext() : base ()
        {

        }
        public EFContext(DbContextOptions<EFContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProdutoMap());

            builder.ApplyConfiguration(new MovimentacaoMap());

            builder.ApplyConfiguration(new CategoriaMap());
            builder.ApplyConfiguration(new ItenVendaMap());
            builder.ApplyConfiguration(new VendaMap());
            //optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=mercado;Username=postgres;Password=007055");
            // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }

        public DbSet<webtest.Objects.Movimentacao> Movimentacao { get; set; }

    }
}
