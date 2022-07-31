using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProduto.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(80)] public string Nome { get; set; }
        [Required] public decimal Preco { get; set; }
        [Required] public int Estoque { get; set; }

    }
}
