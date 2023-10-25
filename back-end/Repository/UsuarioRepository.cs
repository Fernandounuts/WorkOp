using back_end.Infra;
using back_end.Interfaces;
using back_end.Models.UsuarioModel;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repository;

public class UsuarioRepository : IUsuarioRepositoryInterface
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }


    public Task<List<Emprego>> GetAllPastExperiences(long? id)
    {
        return _context.Empregos.Where(e => e.UsuarioId == id).ToListAsync();
    }

    public Task<List<Endereco>> GetAllEnderecos(long? id)
    {
        return _context.Enderecos.Where(e => e.UsuarioId == id).ToListAsync();
    }

    public Task<List<Competencia>> GetAllCompetencias(long? id)
    {
        return _context.Competencias.Where(c => c.UsuarioId == id).ToListAsync();
    }
}