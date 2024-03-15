namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationSettingsDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        AccountNumber = c.String(),
                        CreatedById = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifieById = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedById = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifieById = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedById = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifieById = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedById = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifieById = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemCodeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemCodeId = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        OrderNo = c.Int(),
                        CreatedById = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifieById = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemCodes", t => t.SystemCodeId, cascadeDelete: true)
                .Index(t => t.SystemCodeId);
            
            CreateTable(
                "dbo.SystemCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedById = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifieById = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemCodeDetails", "SystemCodeId", "dbo.SystemCodes");
            DropIndex("dbo.SystemCodeDetails", new[] { "SystemCodeId" });
            DropTable("dbo.SystemCodes");
            DropTable("dbo.SystemCodeDetails");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Banks");
        }
    }
}
