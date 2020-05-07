namespace lab2MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "Fk_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "Fk_DepartmentId");
            AddForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Fk_DepartmentId" });
            DropColumn("dbo.Employees", "Fk_DepartmentId");
            DropTable("dbo.Departments");
        }
    }
}
