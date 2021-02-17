using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Api.Profiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<Survey, SurveyDto>();
        }
    }
}