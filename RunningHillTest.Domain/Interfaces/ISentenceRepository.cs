using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Interfaces
{
    public interface ISentenceRepository
    {
        Task<bool> SaveSentenceAsync(Sentence sentence);
        Task<List<Sentence>> GetSentences();
        Task<Sentence> GetSentenceById(Guid id);
    }
}
