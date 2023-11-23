using ETSFilmesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ETSFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new();
    private static int id = 0;

    [HttpPost]
    public void AdicionarFilmes([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }

    [HttpGet]
    public List<Filme> RetornarFilmes()
    {
        return filmes;
    }
}