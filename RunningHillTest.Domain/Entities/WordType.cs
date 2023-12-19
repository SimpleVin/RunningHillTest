using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningHillTest.Domain.Entities.Common;

namespace RunningHillTest.Domain.Entities
{
    [Table("WordType", Schema = "dbo")]
    public class WordType : BaseEntity<int>
    {
        public required string Text { get; set; }
    }
}
