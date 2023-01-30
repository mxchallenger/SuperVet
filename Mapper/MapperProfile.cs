using AutoMapper;
using SuperVet.DTOs;

namespace SuperVet.Mapper
{
	public class MapperProfile : Profile
	{
        public MapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}

