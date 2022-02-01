using System.ComponentModel.DataAnnotations.Schema;

namespace webtest.Objects
{
    public class Venda 
    {
       [Column("NumVendaId")]
        public int NumVendaId { get; set; }
        [Column("Data/Hora")]
        public DateTime DataHora { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int ClienteId { get; set;  }
        public Cliente Cliente { get; set; }

        public ICollection<Produto> Produtos { get; set; }   
        public ICollection<ItenVenda> ItenVenda { get; set; }
    }
    public class ItenVenda
    {
        [Column("ItemVendaId")]
        public int ItenVendaId { get; set; }
        public  int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public Produto Produto { get; set; }
        public int NumVendaId { get; set; }
        public Venda Venda { get; set; }
        public double Total { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }

}
