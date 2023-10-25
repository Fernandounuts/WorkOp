using back_end.Models.EmpresaModel;
using back_end.Models.UsuarioModel;
using Microsoft.EntityFrameworkCore;

namespace back_end.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Emprego> Empregos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Competencia> Competencias { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<VagasEmprego> VagasEmpregos { get; set; }
}