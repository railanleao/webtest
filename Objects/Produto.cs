using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webtest.Objects
{
    //[Table("Produtos")]
    public class Produto
    {
        //[Key]
        [Column("ProdutoId")]
        public int ProdutoId { get; set; }
        [Column("Nome")]
        //[Required]
        //[StringLength(150)]
        public string Nome { get; set; }
        [Column("Descrição")]
        //[StringLength(500)]
        public string Descricao { get; set; }
        [Column("Quantidade")]
        //[Required]
        [Range(1,10000)]
        public int Quantidade { get; set; }
        [Column("Preços")]
        //[Required]
        [Range(1, 10000)]
        public double Preco { get; set; }
        [Column("Categorias")]
        [Required]
        [StringLength(100)]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [Column("Movimentações")]
        [StringLength(500)]
        public int NumVendaId { get; set; }
        public Venda Venda { get; set; }
        public int ItenVendaId { get; set; }
        public ItenVenda ItenVenda { get; set; }
        public ICollection<Movimentacao> Movimentacao { get; set; }
       
    }
}
