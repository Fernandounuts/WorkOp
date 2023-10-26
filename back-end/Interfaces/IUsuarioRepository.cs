using System.Collections;
using back_end.Models.UsuarioModel;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Emprego>> GetAllPastExperiences(long? id);
    Task<List<Endereco>> GetAllEnderecos(long? id);
    Task<List<Competencia>> GetAllCompetencias(long? id);
    bool UsuarioExists(long? id);
    Task<bool> CreateUsuario(Usuario usuario);
    Task<bool> UpdateUsuario(Usuario usuario);
    Task<bool> DeleteUsuario(Usuario usuario);
    Task<bool> Save();
}