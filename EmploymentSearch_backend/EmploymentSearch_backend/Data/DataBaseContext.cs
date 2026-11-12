using EmploymentSearch_DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIs.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<JobPosition> Position { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){}
    }
}
