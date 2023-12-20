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
    public class WordTypeRepository : IWordTypeRepository
    {
        private readonly ILogger<WordTypeRepository> _logger;
        private readonly IRunningHillDBContext _runningHillDBContext;
        public WordTypeRepository(IRunningHillDBContext runningHillDBContext, ILogger<WordTypeRepository> logger)
        {
            _runningHillDBContext = runningHillDBContext;
            _logger = logger;
        }

        public async Task<List<WordType>> GetWordTypes()
        {
            try
            {
                return await _runningHillDBContext.WordTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving word types");
                throw;
            }
        }

        public async Task<WordType> GetWordTypeById(int id)
        {
            try
            {
                return await _runningHillDBContext.WordTypes.Where(i=> i.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving word types");
                throw;
            }
        }


        public async Task<bool> SaveWordTypeAsync(WordType wordType)
        {
            try
            {

                _runningHillDBContext.WordTypes.Add(wordType);
                var save = await _runningHillDBContext.SaveChangesAsync();
                if (save > 0) return true;
                else return false;
            }
            catch (DbUpdateException ex)
            {
                Log.Error(ex, $"Error saving entity of type {typeof(WordType).Name}");

                throw;
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"Error saving entity of type {typeof(WordType).Name}");
                throw;
            }

        }
    }
}
