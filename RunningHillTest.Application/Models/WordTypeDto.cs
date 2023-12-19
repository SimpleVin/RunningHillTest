using System.ComponentModel;

namespace RunningHillTest.Application.Models
{
    public class WordTypeDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; } 
    }
}
