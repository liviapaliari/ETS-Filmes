using AutoMapper;
using ETSFilmesAPI.DTO;
using ETSFilmesAPI.Model;


namespace ETSFilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<AtualizarFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
        }
    }
}