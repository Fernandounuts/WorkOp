using back_end.Interfaces;
using back_end.Models.UsuarioModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepositoryInterface _user;

    public UsuarioController(IUsuarioRepositoryInterface user)
    {
        _user = user;
    }

    [HttpGet("{UsuarioId}/Empregos")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPastExperiences(long? UsuarioId)
    {
        if (UsuarioId == null)
        {
            return NotFound();
        }

        if (!_user.UsuarioExists(UsuarioId))
        {
            return NotFound();
        }

        return Ok(await _user.GetAllPastExperiences(UsuarioId));
    }

    [HttpGet("{UsuarioId}/Enderecos")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllEnderecos(long? UsuarioId)
    {
        if (UsuarioId == null)
        {
            return NotFound();
        }

        if (!_user.UsuarioExists(UsuarioId))
        {
            return NotFound();
        }

        return Ok(await _user.GetAllEnderecos(UsuarioId));
    }

    [HttpGet("{UsuarioId}/Competencias")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCompetencias(long? UsuarioId)
    {
        if (UsuarioId == null)
        {
            return NotFound();
        }

        if (!_user.UsuarioExists(UsuarioId))
        {
            return NotFound();
        }

        return Ok(await _user.GetAllCompetencias(UsuarioId));
    }
}