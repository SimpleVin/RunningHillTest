using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Interfaces
{
    public interface IWordRepository
    {
        Task<bool> SaveWordAsync(Word word);
        Task<Word> GetWordById(Guid id);
        Task<List<Word>> GetWords();
        Task<List<Word>> GetWordsByWordTypeId(int id);
    }
}
