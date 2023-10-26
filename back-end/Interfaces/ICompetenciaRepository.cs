using back_end.Models.UsuarioModel;

namespace back_end.Interfaces;

public interface ICompetenciaRepository
{
    Task<bool> PostCompetencia(long? id, Competencia competencia);
    Task<bool> UpdateCompetencia(long? id, Competencia competencia);
    Task<bool> DeleteCompetencia(long? id, Competencia competencia);
    Task<bool> Save();
}