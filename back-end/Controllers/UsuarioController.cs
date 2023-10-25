using back_end.Infra;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }
}