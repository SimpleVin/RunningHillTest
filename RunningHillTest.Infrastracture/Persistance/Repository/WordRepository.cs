using Microsoft.EntityFrameworkCore;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Domain.Entities;
using RunningHillTest.Domain.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Infrastructure.Persistance.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly IRunningHillDBContext _runningHillDBContext;
        public WordRepository(IRunningHillDBContext runningHillDBContext)
        {
            _runningHillDBContext = runningHillDBContext;
        }

        public async Task<List<Word>> GetWords()
        {
            try
            {
                return await _runningHillDBContext.Words.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving words");
                throw;
            }
        }

        public async Task<Word> GetWordById(Guid id)
        {
            try
            {
                return await _runningHillDBContext.Words.Where(i=> i.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving word types");
                throw;
            }
        }

        public async Task<bool> SaveWordAsync(Word word)
        {
            try
            {

                _runningHillDBContext.Words.Add(word);
                var save =  await _runningHillDBContext.SaveChangesAsync();
                if(save> 0) return true;
                else return false;
            }
            catch (DbUpdateException ex)
            {
                Log.Error(ex, $"Error saving entity of type {typeof(Word).Name}");

                throw;
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"Error saving entity of type {typeof(Word).Name}");
                throw;
            }

        }

    }
}
