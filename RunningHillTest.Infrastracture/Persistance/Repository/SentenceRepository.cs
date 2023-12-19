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
    public class SentenceRepository : ISentenceRepository
    {
        private readonly IRunningHillDBContext _runningHillDBContext;
        public SentenceRepository(IRunningHillDBContext runningHillDBContext)
        {
            _runningHillDBContext = runningHillDBContext;
        }

        public async Task<Sentence> GetSentenceById(Guid id)
        {
            try
            {
                return await _runningHillDBContext.Sentences.Where(i=>i.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving words");
                throw;
            }
        }

        public async Task<List<Sentence>> GetSentences()
        {
            
                try
                {
                    return await _runningHillDBContext.Sentences.ToListAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error retrieving words");
                    throw;
                }
        }

        public async Task<bool> SaveSentenceAsync(Sentence sentence)
        {
            try
            {

                _runningHillDBContext.Sentences.Add(sentence);
                var save =  await _runningHillDBContext.SaveChangesAsync();
                if (save > 0) return true;
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
