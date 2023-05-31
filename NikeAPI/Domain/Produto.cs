using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NikeAPI.Domain;

public class Produto
{
    [Key]
    public int Id { get; set; }
    [Required,StringLength(100)]
    public string? Nome { get; set; }
    [Required, StringLength(300)]
    public string? Descricao { get; set; }
    [Column(TypeName = "decimal(15,2)" )]
    public decimal Unitario { get; set; }
    [Required, StringLength(300)]
    public string? ImageUrl { get; set; }
    [Column(TypeName = "decimal(15,2)")]
    public decimal Saldo { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
