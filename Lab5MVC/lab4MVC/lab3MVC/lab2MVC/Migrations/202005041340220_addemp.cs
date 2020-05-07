namespace lab2MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
