using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace back_end.Models.UsuarioModel;

public class Usuario
{
    [Key]
    [Required]
    public long UsuarioId { get; set; }

    [MaxLength(60)]
    [NotNull]
    [Required]
    public string? Nome { get; set; }

    public Endereco? Endereco { get; set; }

    [DisplayName("Experiências passadas")]
    public IList<Emprego>? EmpregosPassados { get; set; }

    public IList<Competencia>? Competencias { get; set; }
}