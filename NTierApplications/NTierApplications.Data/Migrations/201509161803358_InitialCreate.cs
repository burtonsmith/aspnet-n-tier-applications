namespace NTierApplications.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 75),
                        JobTitle = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        WebSite = c.String(maxLength: 255),
                        PhoneNumber = c.String(),
                        Notes = c.String(maxLength: 500),
                        NamePrefixId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.NamePrefixes", t => t.NamePrefixId, cascadeDelete: true)
                .Index(t => t.NamePrefixId)
                .Index(t => t.LocationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        City = c.String(),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NamePrefixes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prefix = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillEmployees",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.Employee_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Skill_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.SkillEmployees", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.Employees", "NamePrefixId", "dbo.NamePrefixes");
            DropForeignKey("dbo.Employees", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.SkillEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.SkillEmployees", new[] { "Skill_Id" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "LocationId" });
            DropIndex("dbo.Employees", new[] { "NamePrefixId" });
            DropTable("dbo.SkillEmployees");
            DropTable("dbo.Skills");
            DropTable("dbo.NamePrefixes");
            DropTable("dbo.Locations");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
