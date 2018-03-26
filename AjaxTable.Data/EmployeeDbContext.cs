using AjaxTable.Data.Models;
using System.Data.Entity;

namespace AjaxTable.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(): base("EmployeeConnectionString")
        {

        }
        public DbSet<Employee> Employee { set; get; }

    }
}