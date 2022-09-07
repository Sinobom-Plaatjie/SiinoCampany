using Microsoft.EntityFrameworkCore;
using SiinoCampanyShared.Models;

namespace SinoCampanyApi.Data
{
    public class SinoCampanyContext : DbContext
    {
        
        public SinoCampanyContext(DbContextOptions options) : base(options)
        {
         
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
