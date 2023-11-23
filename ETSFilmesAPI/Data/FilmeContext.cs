using ETSFilmesAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ETSFilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options): base(options)
    {

    }

    public DbSet<Filme> Filmes { get; set; }
}