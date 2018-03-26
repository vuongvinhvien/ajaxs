namespace AjaxTable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "Emloyees");
            AlterColumn("dbo.Emloyees", "Salary", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emloyees", "Salary", c => c.Single(nullable: false));
            RenameTable(name: "dbo.Emloyees", newName: "Employees");
        }
    }
}
