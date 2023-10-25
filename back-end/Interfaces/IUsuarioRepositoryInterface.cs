using System.Collections;
using back_end.Models.UsuarioModel;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Interfaces;

public interface IUsuarioRepositoryInterface
{
    Task<List<Emprego>> GetAllPastExperiences(long? id);
    Task<List<Endereco>> GetAllEnderecos(long? id);
    Task<List<Competencia>> GetAllCompetencias(long? id);
}