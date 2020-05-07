namespace lab2MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mvc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Email");
        }
    }
}
