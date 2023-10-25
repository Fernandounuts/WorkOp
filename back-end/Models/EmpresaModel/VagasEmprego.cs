using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using back_end.Models.UsuarioModel;

namespace back_end.Models.EmpresaModel;

public class VagasEmprego
{
    [Key] public long VagasId { get; set; }

    [Required]
    [MaxLength(30)]
    public string? NomeVaga { get; set; }
    
    [Required]
    [DisplayName("Descrição da Vaga")]
    public string? DescricaoVaga { get; set; }
    
    [Required] 
    [DisplayName("Valor de pagamento")]
    public decimal ValorPagamento { get; set; }
    
    [Required]
    [DisplayName("Candidatos da vaga")]
    public IList<Usuario>? CandidadosVaga { get; set; }
}