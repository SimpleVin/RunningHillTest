using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Uniquely identifies a record in the table")]
        public int Id { get; set; }

        [Description("Keeps record of the date and time the record was added or created")]
        public DateTime CreatedDate { get; set; }
    }
}
