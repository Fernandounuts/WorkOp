using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using back_end.Models.UsuarioModel;

namespace back_end.Models.EmpresaModel;

public class Empresa
{
    [Key] public long EmpresaId { get; set; }

    [Required]
    [DisplayName("Nome da Empresa")]
    [MaxLength(50)]
    public string NomeEmpresa { get; set; }

    [DisplayName("Funcionários")]
    public IList<Usuario>? Funcionarios { get; set; }

    [DisplayName("Vagas de emprego disponíveis")]
    public IList<VagasEmprego>? VagasAbertas { get; set; }
}