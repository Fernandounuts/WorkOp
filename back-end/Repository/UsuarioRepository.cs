using back_end.Infra;
using back_end.Interfaces;
using back_end.Models.UsuarioModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repository;

public class UsuarioRepository : IUsuarioRepository
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

    public bool UsuarioExists(long? id)
    {
        return _context.Usuarios.Any(u => u.UsuarioId == id) ? true : false;
    }

    public async Task<bool> CreateUsuario(Usuario usuario)
    {
        try
        {
            await _context.AddAsync(usuario);
            return await Save();
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }

    public async Task<bool> UpdateUsuario(Usuario usuario)
    {
        _context.Update(usuario);
        return await Save();
    }

    public async Task<bool> DeleteUsuario(Usuario usuario)
    {
        _context.Remove(usuario);
        return await Save();
    }

    public async Task<bool> Save()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}