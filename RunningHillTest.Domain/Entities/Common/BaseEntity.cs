using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Entities.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Uniquely identifies a record in the table")]
        [Required]
        public virtual T Id { get; set; }

        [Description("Keeps record of the date and time the record was added or created")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Description("Keeps record of the date and time the record was last updated")]
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
