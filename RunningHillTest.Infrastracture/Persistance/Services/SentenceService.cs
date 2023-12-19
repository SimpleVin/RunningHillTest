using AutoMapper;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Application.Models;
using RunningHillTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Infrastructure.Persistance.Services
{
    public class SentenceService : ISentenceService
    {
        private readonly ISentenceRepository _sentenceRepository;
        private readonly IMapper _mapper;
        public SentenceService(ISentenceRepository sentenceRepository, IMapper mapper)
        {
            _sentenceRepository = sentenceRepository;
            _mapper = mapper;
        }
        public Task<SentenceDto> GetSentence(Guid sentenceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SentenceDto>> GetSentences()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveSentence(SentenceDto sentence)
        {
            throw new NotImplementedException();
        }
    }
}
