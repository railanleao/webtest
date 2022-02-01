using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webtest.Objects
{
    //[Table("Movimentações")]
    public class Movimentacao
    {   
        //[Key]
        [Column("MovimentaçõesId")]
        public int MovimentacaoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [Column("Descrição")]
        //[StringLength(500)]
        public string Descricao { get; set; }
        [Column("Data/Hora")]
        public DateTime DataHora { get; set; }
    }
}
