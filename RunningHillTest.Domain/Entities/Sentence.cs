using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningHillTest.Domain.Entities.Common;

namespace RunningHillTest.Domain.Entities
{
    [Table("Sentence", Schema = "dbo")]
    public class Sentence :BaseEntity<Guid>
    {
        public required string? Text { get; set; }

        public required string? Words { get; set; }
    }
}
