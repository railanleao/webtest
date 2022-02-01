using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webtest.Objects
{
    //[Table("Clientes")]
    public class Cliente
    {
        //[Key]
        [Column("ClienteId")]
        public int ClienteId { get; set; }
        [Column("Nome")]
        //[Required]
        //[StringLength(150)]
        public string Nome { get; set; }
        [Column("SobreNome")]
        //[Required]
        //[StringLength(150)]
        public string SobreNome { get; set; }
        public ICollection<Venda> Venda { get; set; }
        public ICollection<ItenVenda> ItenVenda { get; set;  }
    }
}
