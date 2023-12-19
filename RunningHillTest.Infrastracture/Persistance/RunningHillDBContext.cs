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
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Database=RunningHill;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WordType>()
                    .HasData(new WordType
                    {
                        Id= 1,
                        Text = "Noun",
                    }, new WordType
                    {
                        Id = 2,
                        Text = "Verb",
                    },
                    new WordType
                    {
                        Id = 3,
                        Text = "Adjective",
                    },
                    new WordType
                    {
                        Id = 4,
                        Text = "Adverb",
                    },
                    new WordType
                    {
                        Id = 5,
                        Text = "Pronoun",
                    },
                    new WordType
                    {
                        Id = 6,
                        Text = "Preposition",
                    },
                    new WordType
                    {
                        Id = 7,
                        Text = "Conjunction",
                    },
                    new WordType
                    {
                        Id = 8,
                        Text = "Determiner",
                    },
                    new WordType
                    {
                        Id = 9,
                        Text = "Exclamation",
                    }
          );
        }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

    }
}
