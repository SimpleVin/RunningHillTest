using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<SentenceRepository> _logger;
        public SentenceRepository(IRunningHillDBContext runningHillDBContext, ILogger<SentenceRepository> logger)
        {
            _runningHillDBContext = runningHillDBContext;
            _logger = logger;
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
                    return await _runningHillDBContext.Sentences.OrderByDescending(i=> i.CreatedDate).ToListAsync();
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
