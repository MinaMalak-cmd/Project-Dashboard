namespace Project_Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        deptId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.deptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        empId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        hiredate = c.DateTime(nullable: false),
                        address = c.String(),
                        salary = c.Int(nullable: false),
                        deptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.empId)
                .ForeignKey("dbo.Departments", t => t.deptId, cascadeDelete: true)
                .Index(t => t.deptId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        location = c.String(maxLength: 20),
                        description = c.String(),
                        deptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.deptId, cascadeDelete: true)
                .Index(t => t.deptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "deptId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "deptId", "dbo.Departments");
            DropIndex("dbo.Projects", new[] { "deptId" });
            DropIndex("dbo.Employees", new[] { "deptId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
