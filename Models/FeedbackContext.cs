using Microsoft.EntityFrameworkCore;
using test_task.Models;

namespace test_task.Migrations
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Theme> Themes { get; set; }

    }
}
