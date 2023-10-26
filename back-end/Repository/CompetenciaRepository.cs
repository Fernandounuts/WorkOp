using back_end.Infra;
using back_end.Interfaces;
using back_end.Models.UsuarioModel;

namespace back_end.Repository;

public class CompetenciaRepository : ICompetenciaRepository
{
    private readonly AppDbContext _context;

    public CompetenciaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> PostCompetencia(long? id, Competencia competencia)
    {
        if (id != null)
        {
            competencia.UsuarioId = id;
        }

        await _context.AddAsync(competencia);
        return await Save();
    }

    public async Task<bool> UpdateCompetencia(long? id, Competencia competencia)
    {
        if (id != null)
        {
            competencia.UsuarioId = id;
        }

        _context.Update(competencia);
        return await Save();

    }

    public async Task<bool> DeleteCompetencia(long? id, Competencia competencia)
    {
        if (id != null)
        {
            competencia.UsuarioId = id;
        }

        _context.Remove(competencia);
        return await Save();
    }

    public async Task<bool> Save()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}