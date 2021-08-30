using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, DTOVeiculo>().ReverseMap();
        }
    }
}
