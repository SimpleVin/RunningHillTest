using AutoMapper;
using RunningHillTest.Application.Models;
using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<WordType, WordTypeDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(x => x.LastUpdatedDate, opt => opt.MapFrom(src => src.LastUpdatedDate))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();


            CreateMap<SentenceDto, Sentence>().ReverseMap();

            CreateMap<WordDto, Word>().ReverseMap();


        }
    }
}
