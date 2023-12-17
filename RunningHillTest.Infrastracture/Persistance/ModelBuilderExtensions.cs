
using Microsoft.EntityFrameworkCore;
using RunningHillTest.Domain.Entities;
using System.Collections.Generic;

namespace RunningHillTest.Infrastructure.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordType>().HasData(PostalCodeList);
            modelBuilder.Entity<Word>().HasData(PostalCodeList);
        }
        public static List<WordType> PostalCodeList => new()
        {
            new WordType { Name = "Noun"},
            new WordType { Name = "Verb"},
            new WordType { Name = "Adjective"},
            new WordType { Name = "Adverb"},
            new WordType { Name = "Pronoun"},
            new WordType { Name = "Preposition"},
            new WordType { Name = "Conjunction"},
            new WordType { Name = "Determiner"},
            new WordType { Name = "Exclamation"}
        };
        
    }
}
