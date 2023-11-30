using System.ComponentModel.DataAnnotations;

namespace ETSFilmesAPI.DTO
{
    public class AtualizarFilmeDTO
    {
        [Required(ErrorMessage = "Título é um campo obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Gênero é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Gênero deve conter até 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Duração é um campo obrigatório")]
        [Range(70, 300, ErrorMessage = "Duração deve ser entre 70 e 300 minutos")]
        public int Duracao { get; set; }
    }
}