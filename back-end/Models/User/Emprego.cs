using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models.User;

public class Emprego
{
    [Required]
    [Key]
    public long EmpregoId { get; set; }
    
    [ForeignKey("Usuario")] public long UsuarioId { get; set; }
    [Required]
    public Usuario Usuario { get; set; }

    [Required]
    [MaxLength(60)]
    [DisplayName("Nome Vaga")]
    public string NomeEmprego { get; set; }

    [MaxLength(150)]
    [DisplayName("Descrição Vaga")]
    public string? DescricaoEmprego { get; set; }
}