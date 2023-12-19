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
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        public WordService(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<WordDto>> GetAllWords()
        {
            throw new NotImplementedException();
        }

        public Task<WordDto> GetWord(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveWord(WordDto word)
        {
            throw new NotImplementedException();
        }
    }
}
