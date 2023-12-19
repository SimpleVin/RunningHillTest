using RunningHillTest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Interfaces
{
    public interface ISentenceService
    {

        Task<SentenceDto> GetSentence(Guid sentenceId);
        Task<bool> SaveSentence(SentenceDto sentence);
        Task<List<SentenceDto>> GetSentences();
    }
}
