using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public virtual Theme Theme { get; set; }

        public virtual Contact Contact { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string content { get; set; }

    }
}
