using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models
{
    public class Theme
    {
        [Key]
        public int ThemesId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ThemeName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public Theme()
        {
            Messages = new List<Message>();
        }
    }
}
