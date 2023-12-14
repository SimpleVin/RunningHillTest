﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Domain.Entities
{
    [Table("Word", Schema = "dbo")]
    public class Word: BaseEntity
    {
        [Description("This is the word")]
        public required string Name { get; set; }
        [Description("This identifies which type of word this belongs to - This links to the Word Type Table")]
        public required int WordTypeId { get; set; }

    }
}