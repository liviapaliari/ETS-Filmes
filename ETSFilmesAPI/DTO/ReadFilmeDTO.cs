namespace ETSFilmesAPI.DTO;

// PARA LEITURA NÃO SÃO NECESSÁRIAS AS ANNOTATIONS
public class ReadFilmeDTO
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }

    public DateTime HoraRequisicao { get; set; } = DateTime.Now;
}