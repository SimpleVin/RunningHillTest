using AutoMapper;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Application.Models;
using RunningHillTest.Domain.Entities;
using RunningHillTest.Domain.Interfaces;
using RunningHillTest.Infrastructure.Persistance.Repository;
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
        public async Task<SentenceDto> GetSentence(Guid sentenceId)
        {
            var words = await _sentenceRepository.GetSentenceById(sentenceId);

            if (words != null)
                return _mapper.Map<SentenceDto>(words);
            else
                return new SentenceDto();
        }

        public async Task<List<SentenceDto>> GetSentences()
        {
            var sentences = await _sentenceRepository.GetSentences();

            if (sentences != null)
                return _mapper.Map<List<SentenceDto>>(sentences);
            else
                return new List<SentenceDto>();
        }

        public async Task<bool> SaveSentence(SentenceDto sentence)
        {
            var sentenceT = _mapper.Map<Sentence>(sentence);
            return await _sentenceRepository.SaveSentenceAsync(sentenceT);
        }
    }
}
