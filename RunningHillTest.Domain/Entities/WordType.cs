using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Entities
{
    [Table("WordType", Schema = "dbo")]
    public class WordType : BaseEntity
    {
        public required string Name { get; set; }
    }
}
