using AutoMapper;
using Vidly.WebApp.Models;
using Vidly.WebApp.Models.Dtos;

namespace Vidly.WebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<MemberShipTypeDto, MemberShipType>();
            CreateMap<MemberShipType, MemberShipTypeDto>();
        }
    }
}