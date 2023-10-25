using back_end.Interfaces;
using back_end.Models.UsuarioModel;
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

    [HttpGet("{usuarioId}/Empregos")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPastExperiences(long? usuarioId)
    {
        if (usuarioId == null)
        {
            return NotFound();
        }

        if (!_user.UsuarioExists(usuarioId))
        {
            return NotFound();
        }

        return Ok(await _user.GetAllPastExperiences(usuarioId));
    }

    [HttpGet("{usuarioId}/Enderecos")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllEnderecos(long? usuarioId)
    {
        if (usuarioId == null)
        {
            return NotFound();
        }

        if (!_user.UsuarioExists(usuarioId))
        {
            return NotFound();
        }

        return Ok(await _user.GetAllEnderecos(usuarioId));
    }

    [HttpGet("{usuarioId}/Competencias")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCompetencias(long? usuarioId)
    {
        if (usuarioId == null)
        {
            return NotFound();
        }

        if (!_user.UsuarioExists(usuarioId))
        {
            return NotFound();
        }

        return Ok(await _user.GetAllCompetencias(usuarioId));
    }
}