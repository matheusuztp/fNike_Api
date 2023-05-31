using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NikeAPI.Domain;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string? Nome { get; set; }
    [Required, StringLength(300)]
    public string? Image { get; set; }

    public ICollection<Produto> Produtos { get; set; }
}
