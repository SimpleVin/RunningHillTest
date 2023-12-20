
using AutoMapper;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Application.Models;
using RunningHillTest.Domain.Entities;
using RunningHillTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Infrastructure.Persistance.Services
{
    public class WordTypeService : IWordTypeService
    {
    private readonly IWordTypeRepository _wordTypeRepository;
        private readonly IMapper _mapper;

        public WordTypeService(IWordTypeRepository wordTypeRepository, IMapper mapper)
        {
            _wordTypeRepository = wordTypeRepository; 
            _mapper = mapper;
        }
        public async Task<WordTypeDto> GetWordType(int wordId)
        {

            var wordType = await _wordTypeRepository.GetWordTypeById(wordId);

            if (wordType != null)
                return _mapper.Map<WordTypeDto>(wordType);
            else
                return new WordTypeDto();
        }

        public async Task<List<WordTypeDto>> GetWordTypes()
        {
            var wordTypes = await _wordTypeRepository.GetWordTypes();

            if (wordTypes != null)
                return _mapper.Map<List<WordTypeDto>>(wordTypes);
            else
                return new List<WordTypeDto>();
        }

        public async Task<bool> SaveWordType(WordTypeDto wordType)
        {
            var wordT = _mapper.Map<WordType>(wordType);
            return await _wordTypeRepository.SaveWordTypeAsync(wordT);
        }
    }
}
