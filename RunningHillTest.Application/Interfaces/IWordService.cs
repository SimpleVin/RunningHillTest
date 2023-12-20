using RunningHillTest.Application.Models;
using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Interfaces
{
    public interface IWordService
    {
        Task<IEnumerable<WordDto>> GetAllWords();
        Task<WordDto> GetWord(Guid id);
        Task<bool> SaveWord(WordDto word);
        Task<List<WordDto>> GetWordsByWordTypeId(int wordTypeId);

    }
}
