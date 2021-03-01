
using Microsoft.EntityFrameworkCore;

namespace WinFormCA.Persistence
{
    public class PersonDbContext : DbContext//, IPersonDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        //public DbSet<Person> Persons { get; set; }
    }
}
