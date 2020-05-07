﻿namespace lab2MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Fk_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Fk_DepartmentId");
            AddForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Fk_DepartmentId" });
            DropColumn("dbo.Employees", "Fk_DepartmentId");
        }
    }
}
