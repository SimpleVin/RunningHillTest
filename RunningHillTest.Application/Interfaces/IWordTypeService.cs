using RunningHillTest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Interfaces
{
    public interface IWordTypeService
    {

        Task<WordTypeDto> GetWordType(int wordId);
        Task<bool> SaveWordType(WordTypeDto sentence);
        Task<List<WordTypeDto>> GetWordTypes();
    }
}
