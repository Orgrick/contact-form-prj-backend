using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ContactName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ContactEmail { get; set; }


        [Column(TypeName = "nvarchar(15)")]
        public string ContactTel { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public Contact()
        {
            Messages = new List<Message>();
        }
    }
}
