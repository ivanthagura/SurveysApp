using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Api.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>();
        }
    }
}