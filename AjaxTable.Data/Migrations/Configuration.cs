namespace AjaxTable.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AjaxTable.Data.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AjaxTable.Data.EmployeeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Employee.AddOrUpdate(
              //p => p.FullName,
              new Employee { Name = "Drop Andrew", Salary= 1234, CreatedDate= DateTime.Now, Status=true },
              new Employee { Name = "Brice Lambson", Salary = 4343, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Andrew Miller", Salary = 6543, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Andrew Peters", Salary = 1234, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Lambson Skill", Salary = 4343, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Rowan Boot", Salary = 6543, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Andrew Coin", Salary = 1234, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Brice Lambson", Salary = 4343, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Rowan John", Salary = 6543, CreatedDate = DateTime.Now, Status = true },
              new Employee { Name = "Andrew Miller", Salary = 1234, CreatedDate = DateTime.Now, Status = true }
            );
            //
            context.SaveChanges();
        }
    }
}
