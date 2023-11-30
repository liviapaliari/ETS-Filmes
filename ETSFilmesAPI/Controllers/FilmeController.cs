using AutoMapper;
using ETSFilmesAPI.Data;
using ETSFilmesAPI.DTO;
using ETSFilmesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ETSFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext context;
    private IMapper mapper;

    // INICIALIZANDO O CONTEXTO
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public IActionResult AdicionarFilmes([FromBody] CreateFilmeDTO createFilmeDTO)
    {
        // Dentro do (qual tipo de dado está vindo)
        // Dentro do <pra qual tipo vai ser convertido>
        Filme filme = mapper.Map<Filme>(createFilmeDTO);
        context.Filmes.Add(filme);
        context.SaveChanges();

        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
    }


    [HttpGet]
    public List<ReadFilmeDTO> RetornarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return mapper.Map<List<ReadFilmeDTO>>(context.Filmes.Skip(skip).Take(take).ToList());
    }


    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId([FromRoute] int id)
    {
        var filme = context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null)
        {
            return NotFound();
        }

        var filmeDTO = mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filme);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizarFilme([FromRoute] int id, AtualizarFilmeDTO filmeDTO)
    {
        var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null)
        {
            return NotFound();
        }

        mapper.Map(filmeDTO, filme);
        context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult ExcluirFilme([FromRoute] int id)
    {
        var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null)
        {
            return NotFound();
        }

        context.Remove(filme);
        context.SaveChanges();
        return NoContent();
    }
}