using Microsoft.EntityFrameworkCore;

namespace PaginationExample
{
    public class PeopleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PeopleDatabase;Trusted_Connection=True;");
        }

        public virtual DbSet<Person> People { get; set; }
    }
}