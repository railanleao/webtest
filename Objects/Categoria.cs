
using System.ComponentModel.DataAnnotations.Schema;

namespace webtest.Objects
{
    //[Table("Categorias")]
    public class Categoria
    {
        //[Key]
        [Column("CategoriaId")]
        public int CategoriaId { get; set; }
        [Column("Nome")]
        //[Required]
        //[StringLength(100)]
        public string Nome { get; set; }
        public ICollection<Produto> Produto { get; set; }
        
             
    }
}
