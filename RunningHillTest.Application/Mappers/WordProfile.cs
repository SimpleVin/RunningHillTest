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
    public class WordProfile : Profile
    {
        public WordProfile()
        {

            CreateMap<WordDto, Word>();
        }
    }
}
