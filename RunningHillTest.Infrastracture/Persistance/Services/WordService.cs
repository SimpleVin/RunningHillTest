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
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        private object wordTypes;

        public WordService(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WordDto>> GetAllWords()
        {
            var words = await _wordRepository.GetWords();

            if (words != null)
                return _mapper.Map<List<WordDto>>(words);
            else
                return new List<WordDto>();
        }

        public async Task<WordDto> GetWord(Guid id)
        {
            var word = await _wordRepository.GetWordById(id);

            if (word != null)
                return _mapper.Map<WordDto>(word);
            else
                return new WordDto();
        }
        public async Task<List<WordDto>> GetWordsByWordTypeId(int id)
        {
            var words = await _wordRepository.GetWordsByWordTypeId(id);

            if (words != null)
                return _mapper.Map<List<WordDto>>(words);
            else
                return new List<WordDto>();
        }

        public async Task<bool> SaveWord(WordDto word)
        {
            var wordT = _mapper.Map<Word>(word);
            return await _wordRepository.SaveWordAsync(wordT);
        }
    }
}
