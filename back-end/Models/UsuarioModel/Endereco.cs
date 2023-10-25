using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models.UsuarioModel;

public class Endereco
{
    [Key]
    [Required]
    public long EnderecoId { get; set; }
    
    [ForeignKey("Usuario")] public long UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    [Required]
    public Estados Estado { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string? Rua { get; set; }
    
    [Required]
    [MaxLength]
    public string? Numero { get; set; }

    [MaxLength(120)]
    public string? Complemento { get; set; }
}