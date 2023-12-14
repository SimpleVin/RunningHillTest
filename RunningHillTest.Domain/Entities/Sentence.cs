using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Entities
{
    [Table("Sentence", Schema = "dbo")]
    public class Sentence :BaseEntity
    {
        public required string? Text { get; set; }

        public required string? Words { get; set; }
    }
}
