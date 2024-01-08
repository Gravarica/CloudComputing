using AutoMapper;
using CentralLibrary.Dto;
using CentralLibrary.Model;

namespace CentralLibrary.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressDTO, Address>();

            CreateMap<RegisterDTO, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.JMBG, opt => opt.MapFrom(src => src.Jmbg))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.NumberOfBooksRented, opt => opt.MapFrom(src => 0));
        }
    }
}
