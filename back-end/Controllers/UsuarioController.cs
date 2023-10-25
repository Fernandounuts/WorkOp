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

    [HttpGet("{UsuarioId}")]
    [ProducesResponseType(200, Type = typeof(IList<Emprego>))]
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

        return Ok(_user.GetAllPastExperiences(UsuarioId));
    }
}