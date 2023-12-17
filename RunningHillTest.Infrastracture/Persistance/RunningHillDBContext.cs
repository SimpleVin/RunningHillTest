using Microsoft.EntityFrameworkCore;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Infrastructure.Persistance
{
    public class RunningHillDBContext : DbContext, IRunningHillDBContext
    {
        public RunningHillDBContext(DbContextOptions<RunningHillDBContext> options)
         : base(options)
        {
        }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Sentence> Sentences { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync(); 
        }
    }
}
