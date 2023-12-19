using Microsoft.EntityFrameworkCore;
using RunningHillTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Interfaces
{
    public interface IRunningHillDBContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        Task<int> SaveChangesAsync();
    }
}
