using BasciASPTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BasciASPTutorial.Data
{
    // applicationDBContext == database
    public class ApplicationDBContext: DbContext
    {
        // constructor method
        // take argument of type DbContextOptions<ApplicationDBContext>
        // DbContextOptions specify various settings about database such as database provider, connection string and other options related to how the context should behave.
        // Conclusion: thsi constructor is used to initiailize the 'ApplicationDBContext' with the specified options, enabling you to oconfigure and connect to a specific database.
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) 
        { 

        }
        // use <Student> to create table name Students
        // to access table use Students 
        public DbSet<Student> Students { get; set; }
    }
}
