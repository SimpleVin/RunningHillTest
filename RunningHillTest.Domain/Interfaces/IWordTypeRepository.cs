using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Interfaces
{
    public interface IWordTypeRepository
    {
        Task<bool> SaveWordTypeAsync(WordType wordType);
        Task<List<WordType>> GetWordTypes();
        Task<WordType> GetWordTypeById(int id);
    }
}
