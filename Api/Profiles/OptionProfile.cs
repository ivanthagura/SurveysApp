using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Api.Profiles
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<Option, OptionDto>();
        }
    }
}