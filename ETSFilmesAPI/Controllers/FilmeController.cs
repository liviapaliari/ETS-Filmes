using ETSFilmesAPI.Data;
using ETSFilmesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ETSFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext context;

    // INICIALIZANDO O CONTEXTO
    public FilmeController(FilmeContext context)
    {
        this.context = context;
    }


    // ENDPOINTS
    [HttpPost]
    public IActionResult AdicionarFilmes([FromBody] Filme filme)
    {
        context.Filmes.Add(filme);
        context.SaveChanges();

        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
    }


    [HttpGet]
    public List<Filme> RetornarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return context.Filmes.Skip(skip).Take(take).ToList();
    }


    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId([FromRoute] int id)
    {
        var filme = context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null)
        {
            return NotFound();
        }

        return Ok(filme);
    }
}