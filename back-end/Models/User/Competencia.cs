using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models.User;

public class Competencia
{
    [Key]
    public long CompetenciaId { get; set; }
    
    [ForeignKey("Usuario")] public long? UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    [Required]
    [MaxLength(30)]
    public string NomeCompetencia { get; set; }
    
    [MaxLength(120)]
    public string? DescCompetencia { get; set; }
}